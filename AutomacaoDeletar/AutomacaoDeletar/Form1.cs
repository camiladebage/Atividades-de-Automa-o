using AutomacaoDeletar.AcessarDados;

namespace AutomacaoDeletar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DeletarDados deletarDados = new DeletarDados();
            //Valor do parametro "select" (esse select acha as tabelas presentes em um banco de dados)
            var result = deletarDados.ExecutarSelect("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");

            //Coloca as linhas do select acima dentro do comboBox
            foreach (var tabela in result)
            {
                comboBox1.Items.Add(tabela);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DeletarDados deletarDados = new DeletarDados();
            //Coloca as tabelas retornadas dentro do comboBox
            deletarDados.Procedure(comboBox1.Text);

            MessageBox.Show("Deletado com sucesso");
        }
    }
}