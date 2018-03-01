using BalancaSolution.Lib.Dados;
using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BalancaSolution.Telas.Tickets
{
    public partial class Pesagem : Form
    {
        Dictionary<int, Lib.Dados.Carga> Cargas = new Dictionary<int, Lib.Dados.Carga>();
        public bool fechar = false;
        bool pesado = false;
        int status_antigo = 0;
        public int ID_Ticket = -1;

        public Pesagem()
        {
            InitializeComponent();
            CarregarComboMotorista();
            CarregarComboProdutos();
            CarregarComboTipo();
            ticketGeraNumeracao();
            pesagemAjustarBotoes();
        }

        #region Pesagem

        private void pesagemBtnLerTara_Click(object sender, EventArgs e)
        {
            try
            {
                pesagemTxtPesoTara.Text = lerPesagem();
                calcularPesoLiquido();
                pesagemCalculaDiferença();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void pesagemBtnLerBruto_Click(object sender, EventArgs e)
        {
            try
            {
                pesagemTxtPesoBruto.Text = lerPesagem();
                calcularPesoLiquido();
                pesagemCalculaDiferença();

            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private string lerPesagem()
        {
            decimal leitura = Lib.Balancas.Comando.lerPesagem();
            if (leitura == -1)
            {
                Lib.Ferramentas.ShowAlertMessageBox("A balança não está pronta ou há um erro de comunicação.", "Alerta");
                return "";
            }
            pesado = true;
            return leitura.ToString();
        }

        private void calcularPesoLiquido()
        {
            if ((pesagemTxtPesoBruto.Text == "") || (pesagemTxtPesoTara.Text == ""))
                return;
            decimal tara, bruto;
            if (!decimal.TryParse(pesagemTxtPesoBruto.Text, out bruto))
                return;
            if (!decimal.TryParse(pesagemTxtPesoTara.Text, out tara))
                return;
            pesagemTxtTotalLiquido.Text = (bruto - tara).ToString("n2");
        }

        private void pesagemCalculaDiferença()
        {
            if (
                ((pesagemTxtTotalNf.Text != "") && (pesagemTxtTotalNf.Text != "0"))
                &&
                ((pesagemTxtTotalLiquido.Text != "") && (pesagemTxtTotalLiquido.Text != "0"))
                )
            {
                float total_nf = float.Parse(pesagemTxtTotalNf.Text);
                float total_liq = float.Parse(pesagemTxtTotalLiquido.Text);
                pesagemTxtTotalDiferencaKg.Text = (total_liq - total_nf).ToString("N2");
                pesagemTxtTotalDiferencaPorcentagem.Text = (100 - ((total_nf / total_liq) * 100)).ToString("N2");
            }
        }

        private void pesagemAjustarBotoes()
        {
            if (!fechar)
            {
                if (ticketRbTipoPesagemCarga.Checked)
                {
                    pesagemBtnLerTara.Enabled = true;
                    pesagemBtnLerBruto.Enabled = false;
                    pesagemTxtPesoBruto.Text = "";
                }
                if (ticketRbTipoPesagemDescarga.Checked)
                {
                    pesagemBtnLerBruto.Enabled = true;
                    pesagemBtnLerTara.Enabled = false;
                    pesagemTxtPesoTara.Text = "";
                }
            }
            else
            {
                ticketPnlRbutons.Enabled = false;
                if (ticketRbTipoPesagemDescarga.Checked)
                {
                    pesagemBtnLerTara.Enabled = true;
                    pesagemBtnLerBruto.Enabled = false;
                }
                if (ticketRbTipoPesagemCarga.Checked)
                {
                    pesagemBtnLerBruto.Enabled = true;
                    pesagemBtnLerTara.Enabled = false;
                }
            }
        }

        #endregion

        #region Ticket

        private void CarregarComboProdutos()
        {
            ticketCbProduto.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Produto", null, Valores);
            ticketCbProduto.DataSource = DT;
            ticketCbProduto.DisplayMember = "Nome";
            ticketCbProduto.ValueMember = "ID";
            ticketCbProduto.SelectedIndex = -1;
        }

        private void CarregarComboTipo()
        {
            ticketCbTipo.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Tipo_De_Veiculo", null, Valores);
            ticketCbTipo.DataSource = DT;
            ticketCbTipo.DisplayMember = "Nome";
            ticketCbTipo.ValueMember = "ID";
            ticketCbTipo.SelectedIndex = -1;
        }

        private void CarregarComboMotorista()
        {
            ticketCbTransportadora.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Transportadora", null, Valores);
            ticketCbTransportadora.DataSource = DT;
            ticketCbTransportadora.DisplayMember = "Nome";
            ticketCbTransportadora.ValueMember = "ID";
            ticketCbTransportadora.SelectedIndex = -1;
        }
        
        private void ticketRbTipoPesagemCarga_CheckedChanged(object sender, EventArgs e)
        {
            if (!fechar)
            {
                if (ticketRbTipoPesagemCarga.Checked)
                {
                    if (ticketTxtDestino.Text.ToLower() == "olvebra")
                        ticketTxtDestino.Text = "";
                    if (ticketTxtProcedencia.Text == "")
                        ticketTxtProcedencia.Text = "Olvebra";
                }
                if (ticketRbTipoPesagemDescarga.Checked)
                {
                    if (ticketTxtDestino.Text == "")
                        ticketTxtDestino.Text = "Olvebra";
                    if (ticketTxtProcedencia.Text.ToLower() == "olvebra")
                        ticketTxtProcedencia.Text = "";
                }
                ticketGeraNumeracao();
                pesagemAjustarBotoes();
            }
        }

        private void ticketTxtPlaca_Leave(object sender, EventArgs e)
        {
            if (ticketTxtPlaca.Text != "")
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Placa", ticketTxtPlaca.Text, TipoDeDadosBD.character));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Veiculo", Condicoes, null);
                if (DT.Rows.Count == 1)
                {
                    ticketCbTipo.SelectedValue = DT.Rows[0]["ID_Tipo"].ToString();
                    ticketCbTransportadora.SelectedValue = DT.Rows[0]["ID_Transportadora"].ToString();

                    List<Parametros> Condicoes_Motora = new List<Parametros>();
                    Condicoes_Motora.Add(new Parametros("ID", DT.Rows[0]["ID_Motorista_Padrao"].ToString(), TipoDeDadosBD.character));
                    DataTable DT_Motorista = Comando.Default.executaComando(TipoDeComando.Select, "Motorista", Condicoes_Motora, null);

                    ticketTxtCpf.Text = DT_Motorista.Rows[0]["CPF"].ToString();
                    ticketTxtNome.Text = DT_Motorista.Rows[0]["Nome"].ToString();
                }
            }
        }

        private void ticketGeraNumeracao()
        {
            if (ticketRbTipoPesagemCarga.Checked)
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Tipo", "C", TipoDeDadosBD.character));
                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("MAX(Codigo) as Codigo", ""));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);
                if (DT.Rows.Count == 1)
                {
                    if(DT.Rows[0]["Codigo"].ToString()!="")
                        ticketTxtNumero.Text = (Int32.Parse(DT.Rows[0]["Codigo"].ToString()) + 1).ToString();
                    else
                        ticketTxtNumero.Text = "1";
                }
                else
                {
                    ticketTxtNumero.Text = "1";
                }
            }
            if (ticketRbTipoPesagemDescarga.Checked)
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Tipo", "D", TipoDeDadosBD.character));
                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("MAX(Codigo) as Codigo", ""));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);
                if (DT.Rows.Count == 1)
                {
                    if (DT.Rows[0]["Codigo"].ToString() != "")
                        ticketTxtNumero.Text = (Int32.Parse(DT.Rows[0]["Codigo"].ToString()) + 1).ToString();
                    else
                        ticketTxtNumero.Text = "1";
                }
                else
                {
                    ticketTxtNumero.Text = "1";
                }
            }
        }


        #endregion

        #region Carga

        private void cargaBtnAdicionar_Click(object sender, EventArgs e)
        {
            adicionarCarga();
        }

        private void adicionarCarga()
        {
            if (!cargaValidarCampos())
                return;
            int numero = int.Parse(cargaTxtNumero.Text);
            float volume = float.Parse(cargaNudVolumes.Value.ToString());
            float peso = float.Parse(cargaNudPeso.Value.ToString());
            Cargas.Add(numero, new Lib.Dados.Carga(numero, volume, peso));
            cargaTxtTotalVolumes.Text = (float.Parse(cargaTxtTotalVolumes.Text) + volume).ToString();
            cargaAtualizaListView();
            cargaAtualizarPesoCargas(peso);
            cargaTxtNumero.Text = "";
            cargaNudVolumes.Value = 0;
            cargaNudPeso.Value = 0;
            cargaTxtNumero.Focus();
        }

        private void cargaAtualizarPesoCargas(float peso)
        {
            pesagemTxtTotalNf.Text = (float.Parse(pesagemTxtTotalNf.Text) + peso).ToString();
            pesagemCalculaDiferença();
        }

        private bool cargaValidarCampos()
        {
            if (cargaTxtNumero.Text == "")
            {
                Lib.Ferramentas.ShowAlertMessageBox("Preencha o campo Número.", "Alerta");
                return false;
            }
            if (cargaNudVolumes.Value <= 0)
            {
                Lib.Ferramentas.ShowAlertMessageBox("Volume deve ser maior que zero.", "Alerta");
                return false;
            }
            if (cargaNudPeso.Value <= 0)
            {
                Lib.Ferramentas.ShowAlertMessageBox("Peso deve ser maior que zero.", "Alerta");
                return false;
            }
            int teste;
            if (!int.TryParse(cargaTxtNumero.Text, out teste))
            {
                Lib.Ferramentas.ShowAlertMessageBox("O campo Número deve ser preenchido com somente com números.", "Alerta");
                return false;
            }

            if (Cargas.ContainsKey(int.Parse(cargaTxtNumero.Text)))
            {
                Lib.Ferramentas.ShowAlertMessageBox("Nota fiscal ou ordem de carga já cadastrada.", "Alerta");
                return false;
            }
            return true;
        }

        private void cargaAtualizaListView()
        {
            cargaLsvDados.Items.Clear();
            cargaLsvDados.SetObjects(Cargas.Values);
        }

        private void cargaBtnRRemover_Click(object sender, EventArgs e)
        {
            DeletarRegistro();
        }

        private void cargaBtnCancelar_Click(object sender, EventArgs e)
        {
            cargaTxtNumero.Text = "";
            cargaNudVolumes.Text = "";
            cargaNudPeso.Value = 0;
        }

        #endregion

        #region salvar

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarRegistro();
        }

        private bool geralValidarCampos()
        {

            #region Validação Pesagem

            #region Tipo de pesagem X Pesagem realizada

            if ((!fechar) ||(status_antigo==3))
            {
                if ((ticketRbTipoPesagemCarga.Checked) && ((pesagemTxtPesoTara.Text == "") || (float.Parse(pesagemTxtPesoTara.Text) == 0)))
                {
                    if (MessageBox.Show("Nenhuma pesagem foi feita, deseja salvar o ticket assim mesmo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        geralSalvarAberto();
                        return false;
                    }
                    tabControl1.SelectedTab = tb_pesagem;
                    Lib.Ferramentas.ShowAlertMessageBox("Favor realizar a pesagem do peso tara.", "Alerta");
                    return false;
                }
                if ((ticketRbTipoPesagemDescarga.Checked) && ((pesagemTxtPesoBruto.Text == "") || (float.Parse(pesagemTxtPesoBruto.Text) == 0)))
                {
                    if (MessageBox.Show("Nenhuma pesagem foi feita, deseja salvar o ticket assim mesmo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        geralSalvarAberto();
                        return false;
                    }
                    tabControl1.SelectedTab = tb_pesagem;
                    Lib.Ferramentas.ShowAlertMessageBox("Favor realizar a pesagem do peso bruto.", "Alerta");
                    return false;
                }
            }
            else
            {
                if ((ticketRbTipoPesagemDescarga.Checked) && ((pesagemTxtPesoTara.Text == "") || (float.Parse(pesagemTxtPesoTara.Text) == 0)))
                {
                    if (MessageBox.Show("Nenhuma pesagem foi feita, deseja salvar o ticket assim mesmo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        geralSalvarEdicao();
                        return false;
                    }
                    tabControl1.SelectedTab = tb_pesagem;
                    Lib.Ferramentas.ShowAlertMessageBox("Favor realizar a pesagem do peso tara.", "Alerta");
                    return false;
                }
                if ((ticketRbTipoPesagemCarga.Checked) && ((pesagemTxtPesoBruto.Text == "") || (float.Parse(pesagemTxtPesoBruto.Text) == 0)))
                {
                    if (MessageBox.Show("Nenhuma pesagem foi feita, deseja salvar o ticket assim mesmo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        geralSalvarEdicao();
                        return false;
                    }
                    tabControl1.SelectedTab = tb_pesagem;
                    Lib.Ferramentas.ShowAlertMessageBox("Favor realizar a pesagem do peso bruto.", "Alerta");
                    return false;
                }
            }

            #endregion

            #region Diferença X Tolerancia

            if ((fechar) && (status_antigo!=3))
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("ID", ID_Ticket.ToString(), TipoDeDadosBD.numerico));

                DataTable DT_Produto = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, null);
                float margem = float.Parse(DT_Produto.Rows[0]["Produto_Margem"].ToString());
                char tipo_margem = DT_Produto.Rows[0]["Produto_Tipo_Margem"].ToString().ToLower()[0];

                switch (tipo_margem)
                {
                    case 'k':
                        if (pesagemTxtTotalDiferencaKg.Text == "")
                        {
                            if (MessageBox.Show("Não foi possível calcular a diferença, tem certeza que deseja salvar o ticket?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                break;
                            }
                            else
                                return false;
                        }
                        float dif = float.Parse(pesagemTxtTotalDiferencaKg.Text);
                        if (dif < 0)
                            dif = dif * -1;
                        if (margem > dif)
                            return true;
                        else
                        {
                            if (MessageBox.Show("Diferença entre a pesagem e a carga informada fora do limite,\n deseja continuar com o salvamento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                    case 'p':
                        if (pesagemTxtTotalDiferencaPorcentagem.Text == "")
                        {
                            if (MessageBox.Show("Não foi possível calcular a diferença, tem certeza que deseja salvar o ticket?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                break;
                            }
                        }
                        if (margem > float.Parse(pesagemTxtTotalDiferencaPorcentagem.Text))
                            return true;
                        else
                        {
                            if (MessageBox.Show("Diferença entre a pesagem e a carga informada fora do limite,\n deseja continuar com o salvamento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                    default:
                        return false;
                }
            }

            #endregion

            #endregion

            #region Validação Ticket

            if (ticketCbProduto.SelectedIndex == -1)
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Escolha o produto.", "Alerta");
                return false;
            }
            if (ticketTxtProcedencia.Text =="")
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha a procedencia.", "Alerta");
                return false;
            }
            if (ticketTxtDestino.Text == "")
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha o destino.", "Alerta");
                return false;
            }
            if (ticketTxtPlaca.Text == "")
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha a placa do veiculo.", "Alerta");
                return false;
            }
            if (ticketCbTipo.SelectedIndex == -1)
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Escolha o tipo de veiculo.", "Alerta");
                return false;
            }
            if (ticketCbTransportadora.SelectedIndex == -1)
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Escolha a transportadora.", "Alerta");
                return false;
            }
            /*
            if (ticket_txt_cpf.Text == "")
            {
                tabControl1.SelectedTab = tb_ticket;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha o cpf do motorista.", "Alerta");
                return false;
            }
            */
            if (ticketTxtNome.Text == "")
            {
                tabControl1.SelectedTab = tbTicket;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha o nome do motorista.", "Alerta");
                return false;
            }

            #endregion

            #region Validação Carga

            if ((Cargas.Count == 0) && (fechar))
            {
                tabControl1.SelectedTab = tbCarga;
                Lib.Ferramentas.ShowAlertMessageBox("Preencha pelo menos uma carga.", "Alerta");
                return false;
            }
            #endregion

            return true;
        }

        private void ticketTxtCpf_Leave(object sender, EventArgs e)
        {
            if (ticketTxtCpf.Text != "")
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("CPF", ticketTxtCpf.Text, OperadorComparativo.EQUALS));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Motorista", Condicoes, null);
                if (DT.Rows.Count > 0)
                {
                    ticketTxtNome.Text = DT.Rows[0]["Nome"].ToString();
                }
            }
        }

        private bool TestarMotorista()
        {
            List<Parametros> Condicoes = new List<Parametros>();
            if (!string.IsNullOrWhiteSpace(ticketTxtCpf.Text))
                Condicoes.Add(new Parametros("CPF", ticketTxtCpf.Text, TipoDeDadosBD.character));
            Condicoes.Add(new Parametros("Nome", ticketTxtNome.Text, TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Motorista", Condicoes, null);
            if (DT.Rows.Count <= 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Motorista não cadastrado, deseja cadastrar esse motorista e proseguir com a pesagem?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    
                    List<Parametros> Valores = new List<Parametros>();
                    if (!string.IsNullOrWhiteSpace(ticketTxtCpf.Text))
                    {
                        if (IsCpf(ticketTxtCpf.Text))
                            Valores.Add(new Parametros("CPF", ticketTxtCpf.Text, TipoDeDadosBD.numerico));
                        else
                        {
                            Lib.Ferramentas.ShowAlertMessageBox("CPF invalido.", "Aviso");
                            return false;
                        }
                    }
                    Valores.Add(new Parametros("Nome", ticketTxtNome.Text, TipoDeDadosBD.character));

                    Comando.Default.executaComando(TipoDeComando.Insert, "Motorista", null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Motorista " + ticketTxtNome.Text + " foi criado.");
                    return true;
                }
                else
                { return false; }
            }
            return true;
        }

        private bool TestarVeiculo()
        {
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Placa", ticketTxtPlaca.Text, TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Veiculo", Condicoes, null);
            if (DT.Rows.Count <= 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Veiculo não cadastrado, deseja cadastrar esse veiculo e proseguir com a pesagem?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    List<Parametros> Valores = new List<Parametros>();

                    Valores.Add(new Parametros("Placa", ticketTxtPlaca.Text, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("ID_Tipo", ticketCbTipo.SelectedValue.ToString(), TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("ID_Transportadora", ticketCbTransportadora.SelectedValue.ToString(), TipoDeDadosBD.numerico));

                    if (!TestarMotorista())
                        return false;

                    Condicoes = new List<Parametros>();
                    if (!string.IsNullOrWhiteSpace(ticketTxtCpf.Text))
                        Condicoes.Add(new Parametros("CPF", ticketTxtCpf.Text, TipoDeDadosBD.character));
                    Condicoes.Add(new Parametros("Nome", ticketTxtNome.Text, TipoDeDadosBD.character));
                    DT = Comando.Default.executaComando(TipoDeComando.Select, "Motorista", Condicoes, null);

                    Valores.Add(new Parametros("ID_Motorista_Padrao", DT.Rows[0]["ID"].ToString(), TipoDeDadosBD.numerico));

                    Comando.Default.executaComando(TipoDeComando.Insert, "Veiculo", null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Veiculo " + ticketTxtPlaca.Text + " foi criado.");
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private void geralSalvarAberto()
        {
            Comando.Default.executaComando(TipoDeComando.Insert, "Ticket", null, montarValoresASeremSalvos());

            gravarCarga2();

            if (Properties.Settings.Default.Modo_Log)
            {
                if (ticketRbTipoPesagemCarga.Checked)
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo C foi criado em modo aberto.");
                else
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo D foi criado em modo aberto.");
            }

            this.Close();
        }

        private void geralSalvarEdicao()
        {
            List<Parametros> Condicoes = new List<Parametros>();

            Condicoes.Add(new Parametros("ID", ID_Ticket.ToString(), OperadorComparativo.EQUALS));

            Comando.Default.executaComando(TipoDeComando.Update, "Ticket", Condicoes, montarValoresASeremSalvos());

            gravarCarga2();

            if (Properties.Settings.Default.Modo_Log)
            {
                char tipo;
                if (ticketRbTipoPesagemCarga.Checked)
                    tipo = 'C';
                else
                    tipo = 'D';

                Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo " + tipo + " foi atualizado.");
            }

            this.Close();
        }

        private void geralSalvar1()
        {

            if (!TestarMotorista())
                return;

            if (!TestarVeiculo())
                return;
            
            Comando.Default.executaComando(TipoDeComando.Insert, "Ticket", null, montarValoresASeremSalvos());

            gravarCarga1();

            if (Properties.Settings.Default.Modo_Log)
            {
                if (ticketRbTipoPesagemCarga.Checked)
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo C foi criado.");
                else
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo D foi criado.");
            }
        }

        private void gravarCarga1()
        {
            List<SQLiteCommand> ListaComandos = new List<SQLiteCommand>();

            List<Parametros> Valores = new List<Parametros>();
            string sql = @"SELECT MAX(ID) as ID FROM Ticket";
            DataTable DT_Ticket = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", null, null, sql);
            ID_Ticket = int.Parse(DT_Ticket.Rows[DT_Ticket.Rows.Count-1]["ID"].ToString());
            foreach (Carga c in Cargas.Values)
            {
                Valores = new List<Parametros>();
                Valores.Add(new Parametros("Numero", c.Numero.ToString(), TipoDeDadosBD.numerico));
                Valores.Add(new Parametros("Volumes", c.Volumes.ToString(), TipoDeDadosBD.pontoFlutuante));
                Valores.Add(new Parametros("Peso", c.Peso.ToString(), TipoDeDadosBD.pontoFlutuante));
                Valores.Add(new Parametros("ID_Ticket", ID_Ticket.ToString(), TipoDeDadosBD.numerico));
                ListaComandos.Add(Validador.MontarInsertSQLite("Carga", Valores));
            }
            Validador.ExecutarTransactionSQLite(ListaComandos, (SQLiteConnection)Comando.Default.conexaoBanco);
            ID_Ticket = -1;
        }

        private void geralSalvar2()
        {
            List<Parametros> Condicoes = new List<Parametros>();

            Condicoes.Add(new Parametros("ID", ID_Ticket.ToString(), OperadorComparativo.EQUALS));

            
            Comando.Default.executaComando(TipoDeComando.Update, "Ticket", Condicoes, montarValoresASeremSalvos());

            if (Properties.Settings.Default.Modo_Log)
            {
                char tipo;
                if (ticketRbTipoPesagemCarga.Checked)
                    tipo = 'C';
                else
                    tipo = 'D';

                Lib.Log.Log.gravarMenssagemDataHora("Ticket " + ticketTxtNumero + " do tipo " + tipo + " foi finalizado.");
            }
        }

        private void gravarCarga2()
        {
            List<SQLiteCommand> ListaComandos = new List<SQLiteCommand>();

            string sql = @"DELETE FROM Carga
WHERE ID_Ticket = "+ID_Ticket;
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("ID_Ticket",ID_Ticket.ToString()));

            ListaComandos.Add(Validador.MontarDeleteSQLite("Carga", Condicoes));

            Comando.Default.executaComando(TipoDeComando.Sql, "Carga", null, null,sql);
            foreach (Carga c in Cargas.Values)
            {
                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("Numero", c.Numero.ToString(), TipoDeDadosBD.numerico));
                Valores.Add(new Parametros("Volumes", c.Volumes.ToString(), TipoDeDadosBD.pontoFlutuante));
                Valores.Add(new Parametros("Peso", c.Peso.ToString(), TipoDeDadosBD.pontoFlutuante));
                Valores.Add(new Parametros("ID_Ticket", ID_Ticket.ToString(), TipoDeDadosBD.numerico));
                ListaComandos.Add(Validador.MontarInsertSQLite("Carga", Valores));
            }

            if (Cargas.Values.Count > 0)
            {
                Validador.ExecutarTransactionSQLite(ListaComandos, (SQLiteConnection)Comando.Default.conexaoBanco);
                //Comando.Default.CommitTransaction();
            }
        }

        private List<Parametros> montarValoresASeremSalvos()
        {
            #region variaveis

            List<Parametros> Valores = new List<Parametros>();
            int codigo = int.Parse(ticketTxtNumero.Text);
            char tipo;
            if (ticketRbTipoPesagemCarga.Checked)
                tipo = 'C';
            else
                tipo = 'D';
            string procedencia = ticketTxtProcedencia.Text;
            string destino = ticketTxtDestino.Text;
            int status = 2;
            int qtd_carga = int.Parse(cargaTxtTotalVolumes.Text);

            float peso_tara = 0;
            float peso_bruto = 0;
            float peso_liquido = 0;

            DateTime data_bruto = DateTime.Now.AddYears(-1000);
            DateTime data_tara = DateTime.Now.AddYears(-1000);

            DateTime data = DateTime.Now;
            DateTime data_saida = DateTime.Now.AddYears(-1000);

            float peso_liquido_nf = float.Parse(pesagemTxtTotalNf.Text);
            float diferenca = -1;

            DateTime data_fechamento = DateTime.Now.AddYears(-1000);

            string observacao = pesagemTxtObservacao.Text;

            long motorista_cpf = -1;
            if (!string.IsNullOrWhiteSpace(ticketTxtCpf.Text))
                motorista_cpf = long.Parse(ticketTxtCpf.Text);
            string motorista_nome = ticketTxtNome.Text;

            string veiculo_placa = ticketTxtPlaca.Text;
            string veiculo_tipo = ticketCbTipo.Text;
            string veiculo_transportadora = ticketCbTransportadora.Text;

            string produto_nome = "";
            string produto_margem = "0";
            string produto_tipo_margem = "0";

            if (ticketCbProduto.SelectedIndex != -1)
            {
                Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
                Valores.Add(new Parametros("Margem", "", TipoDeDadosBD.character));
                Valores.Add(new Parametros("Tipo_Margem", "", TipoDeDadosBD.character));
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("ID", ticketCbProduto.SelectedValue.ToString(), OperadorComparativo.EQUALS));
                DataTable DT_Produtos = Comando.Default.executaComando(TipoDeComando.Select, "Produto", Condicoes, Valores);

                produto_nome = DT_Produtos.Rows[0]["Nome"].ToString();
                produto_margem = DT_Produtos.Rows[0]["Margem"].ToString();
                produto_tipo_margem = DT_Produtos.Rows[0]["Tipo_Margem"].ToString();
            }

            if ((!fechar) || (status_antigo == 3))
            {
                if (ticketRbTipoPesagemCarga.Checked)
                {
                    if (!string.IsNullOrEmpty(pesagemTxtPesoTara.Text))
                    {
                        peso_tara = float.Parse(pesagemTxtPesoTara.Text);
                        data_bruto = data_bruto.AddYears(-1000);
                    }
                }
                if (ticketRbTipoPesagemDescarga.Checked)
                {
                    if (!string.IsNullOrEmpty(pesagemTxtPesoBruto.Text))
                    {
                        peso_bruto = float.Parse(pesagemTxtPesoBruto.Text);
                        data_tara = data_tara.AddYears(-1000);
                    }
                }
                peso_liquido = float.Parse(pesagemTxtTotalLiquido.Text);
            }
            else
            {
                peso_tara = float.Parse(pesagemTxtPesoTara.Text);    
                peso_bruto = float.Parse(pesagemTxtPesoBruto.Text);
                peso_liquido = float.Parse(pesagemTxtTotalLiquido.Text);
                if (produto_tipo_margem.ToLower() == "k")
                {
                    if (!string.IsNullOrEmpty(pesagemTxtTotalDiferencaKg.Text))
                        diferenca = float.Parse(pesagemTxtTotalDiferencaKg.Text);
                    else
                        diferenca = -1;
                }
                else if (produto_tipo_margem.ToLower() == "p")
                {
                    if (!string.IsNullOrEmpty(pesagemTxtTotalDiferencaPorcentagem.Text))
                        diferenca = float.Parse(pesagemTxtTotalDiferencaPorcentagem.Text);
                    else
                        diferenca = -1;
                }
            }

            #endregion

            Valores = new List<Parametros>();
            if (fechar)
            {
                if ((peso_bruto != 0) && (peso_tara != 0))
                {
                    #region gravar 2

                    Valores.Add(new Parametros("Procedencia", procedencia, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Destino", destino, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Status", "1", TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("Peso_Liquido", peso_liquido.ToString(), TipoDeDadosBD.pontoFlutuante));

                    if (ticketRbTipoPesagemCarga.Checked)
                    {
                        Valores.Add(new Parametros("Peso_Bruto", peso_bruto.ToString(), TipoDeDadosBD.pontoFlutuante));
                        Valores.Add(new Parametros("Data_Bruto", data_bruto.ToString(), TipoDeDadosBD.data));
                    }
                    if (ticketRbTipoPesagemDescarga.Checked)
                    {
                        Valores.Add(new Parametros("Peso_Tara", peso_tara.ToString(), TipoDeDadosBD.pontoFlutuante));
                        Valores.Add(new Parametros("Data_Tara", data_tara.ToString(), TipoDeDadosBD.data));
                    }
                    Valores.Add(new Parametros("Data", data.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Data_Saida", data_saida.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Peso_Liquido", peso_liquido.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Diferenca", diferenca.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Data_Fechamento", data_fechamento.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Observacao", observacao, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Quantidade_Cargas", qtd_carga.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Peso_Liquido_NF", peso_liquido_nf.ToString(), TipoDeDadosBD.character));


                    #endregion
                }
                else
                {
                    #region salvar edição

                    Valores.Add(new Parametros("Procedencia", procedencia, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Destino", destino, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Observacao", observacao, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Quantidade_Cargas", qtd_carga.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Peso_Liquido_NF", peso_liquido_nf.ToString(), TipoDeDadosBD.character));
                    if (motorista_cpf != -1)
                        Valores.Add(new Parametros("Motorista_CPF", motorista_cpf.ToString(), TipoDeDadosBD.numericoLongo));
                    Valores.Add(new Parametros("Motorista_Nome", motorista_nome.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Placa", veiculo_placa, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Tipo", veiculo_tipo, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Transportadora", veiculo_transportadora, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Nome", produto_nome, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Margem", produto_margem, TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Produto_Tipo_Margem", produto_tipo_margem, TipoDeDadosBD.character));

                    if (pesado)
                    {
                        Valores.Add(new Parametros("Status", "0", TipoDeDadosBD.numerico));
                        Valores.Add(new Parametros("Data_Bruto", data_bruto.ToString(), TipoDeDadosBD.data));
                        Valores.Add(new Parametros("Data_Tara", data_tara.ToString(), TipoDeDadosBD.data));
                        Valores.Add(new Parametros("Peso_Bruto", peso_bruto.ToString(), TipoDeDadosBD.pontoFlutuante));
                        Valores.Add(new Parametros("Peso_Tara", peso_tara.ToString(), TipoDeDadosBD.pontoFlutuante));
                    }
                    #endregion
                }
            }
            else
            {
                if ((peso_bruto == 0) && (peso_tara == 0))
                {
                    #region salvar aberto

                    Valores = new List<Parametros>();
                    Valores.Add(new Parametros("Codigo", codigo.ToString(), TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("Tipo", tipo.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Procedencia", procedencia, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Destino", destino, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Status", "3", TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("Data", data.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Peso_Liquido_NF", peso_liquido_nf.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Observacao", observacao, TipoDeDadosBD.character));
                    if (motorista_cpf != -1)
                        Valores.Add(new Parametros("Motorista_CPF", motorista_cpf.ToString(), TipoDeDadosBD.numericoLongo));
                    Valores.Add(new Parametros("Motorista_Nome", motorista_nome.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Placa", veiculo_placa, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Tipo", veiculo_tipo, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Transportadora", veiculo_transportadora, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Nome", produto_nome, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Margem", produto_margem, TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Produto_Tipo_Margem", produto_tipo_margem, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Quantidade_Cargas", qtd_carga.ToString(), TipoDeDadosBD.character));

                    #endregion
                }
                else
                {
                    #region gravar 1

                    Valores = new List<Parametros>();
                    Valores.Add(new Parametros("Codigo", codigo.ToString(), TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("Tipo", tipo.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Procedencia", procedencia, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Destino", destino, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Status", "0", TipoDeDadosBD.numerico));
                    Valores.Add(new Parametros("Peso_Bruto", peso_bruto.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Peso_Tara", peso_tara.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Data", data.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Data_Bruto", data_bruto.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Data_Tara", data_tara.ToString(), TipoDeDadosBD.data));
                    Valores.Add(new Parametros("Peso_Liquido_NF", peso_liquido_nf.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Diferenca", diferenca.ToString(), TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Observacao", observacao, TipoDeDadosBD.character));
                    if (motorista_cpf != -1)
                        Valores.Add(new Parametros("Motorista_CPF", motorista_cpf.ToString(), TipoDeDadosBD.numericoLongo));
                    Valores.Add(new Parametros("Motorista_Nome", motorista_nome.ToString(), TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Placa", veiculo_placa, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Tipo", veiculo_tipo, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Veiculo_Transportadora", veiculo_transportadora, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Nome", produto_nome, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Produto_Margem", produto_margem, TipoDeDadosBD.pontoFlutuante));
                    Valores.Add(new Parametros("Produto_Tipo_Margem", produto_tipo_margem, TipoDeDadosBD.character));
                    Valores.Add(new Parametros("Quantidade_Cargas", qtd_carga.ToString(), TipoDeDadosBD.character));

                    #endregion
                }
            }
            return Valores;
        }

        #endregion

        private void Pesagem_Load(object sender, EventArgs e)
        {
            if (ID_Ticket != -1)
            {
                carregarDados();
            }
        }

        private void carregarDados()
        {
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("ID", ID_Ticket.ToString(), OperadorLogico.AND));
            DataTable DT_Ticket = Comando.Default.executaComando(TipoDeComando.Select, "Ticket",Condicoes, null);

            DataRow DR = DT_Ticket.Rows[0];

            ticketTxtNumero.Text = DR["codigo"].ToString();
            char tipo = DR["Tipo"].ToString()[0];
            if (tipo == 'C')
                ticketRbTipoPesagemCarga.Checked = true;
            else
                ticketRbTipoPesagemDescarga.Checked = true;
            status_antigo = int.Parse(DR["Status"].ToString());

            if(status_antigo!=3)
                pesagemAjustarBotoes();

            ticketTxtProcedencia.Text = DR["Procedencia"].ToString();
            ticketTxtDestino.Text = DR["Destino"].ToString();

            ticketCbProduto.SelectedIndex = ticketCbProduto.FindStringExact(DR["Produto_Nome"].ToString());
            //ticket_cb_produto.SelectedText = DR["Produto_Nome"].ToString();

            pesagemTxtPesoTara.Text = DR["Peso_Tara"].ToString();
            pesagemTxtPesoBruto.Text = DR["Peso_Bruto"].ToString();

            pesagemTxtObservacao.Text = DR["Observacao"].ToString();

            ticketTxtPlaca.Text = DR["Veiculo_Placa"].ToString();
            ticketCbTipo.SelectedIndex = ticketCbTipo.FindStringExact(DR["Veiculo_Tipo"].ToString());
            //ticket_cb_tipo.SelectedText = DR["Veiculo_Tipo"].ToString();
            ticketCbTransportadora.SelectedIndex = ticketCbTransportadora.FindStringExact(DR["Veiculo_Transportadora"].ToString());
            //ticket_cb_transportadora.SelectedText = DR["Veiculo_Transportadora"].ToString();

            ticketTxtCpf.Text = DR["Motorista_CPF"].ToString();
            ticketTxtNome.Text = DR["Motorista_Nome"].ToString();

            if (status_antigo != 3)
            {
                ticketCbProduto.Enabled = false;
                ticketGbVeiculo.Enabled = false;
                ticketPnlRbutons.Enabled = false;
            }

            Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("ID_Ticket", ID_Ticket.ToString(), OperadorLogico.AND));
            DataTable DT_Carga = Comando.Default.executaComando(TipoDeComando.Select, "Carga", Condicoes, null);

            foreach (DataRow c in DT_Carga.Rows)
            {
                Cargas.Add(int.Parse(c["Numero"].ToString()), new Lib.Dados.Carga(int.Parse(c["Numero"].ToString()), float.Parse(c["Volumes"].ToString()), float.Parse(c["Peso"].ToString())));
                cargaTxtTotalVolumes.Text = (float.Parse(cargaTxtTotalVolumes.Text) + float.Parse(c["Volumes"].ToString())).ToString();
                cargaAtualizarPesoCargas(float.Parse(c["Peso"].ToString()));
            }
            cargaAtualizaListView();

            if (DR["Status"].ToString() == "1")
                TicketFechado();
        }

        private void TicketFechado()
        {
            btnSalvar.Visible = false;
            btnCancelar.Text = "Fechar";
            btnImprimir.Visible = true;
            //tabControl1.Enabled = false;
            foreach (TabPage tab in tabControl1.TabPages) EnableTab(tab, false);
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("ID", ID_Ticket.ToString(), OperadorLogico.AND));
                DataTable DT_Ticket = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, null);
                DataRow DR = DT_Ticket.Rows[0];

                Lib.Relatorio.Ticket rel = new Lib.Relatorio.Ticket();
                rel.Codigo = int.Parse(ticketTxtNumero.Text);
                rel.Tipo = DR["Tipo"].ToString();
                rel.ImprimirRelatorio();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void Pesagem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
                case Keys.Delete:
                    if (cargaLsvDados.Focused)
                        DeletarRegistro();
                    break;
                case Keys.Enter:
                    SalvarRegistro();
                    break;
                case Keys.F10:
                    adicionarCarga();
                    break;
            }
        }

        private void SalvarRegistro()
        {
            try
            {
                if (!geralValidarCampos())
                    return;
                if (!fechar)
                    geralSalvar1();
                else
                    geralSalvar2();

                this.Close();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void DeletarRegistro()
        {
            if (cargaLsvDados.SelectedItem != null)
            {
                int num = int.Parse(cargaLsvDados.SelectedItem.Text.ToString());
                cargaAtualizarPesoCargas(Cargas[num].Peso * -1);
                cargaTxtTotalVolumes.Text = (float.Parse(cargaTxtTotalVolumes.Text) - Cargas[num].Volumes).ToString();
                Cargas.Remove(num);
                cargaAtualizaListView();
            }
        }

        private void Sair()
        {
            if (MessageBox.Show("Tem certeja que deseja abandonar a pesagem?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

    }
}
