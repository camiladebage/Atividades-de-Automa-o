using System.Text.RegularExpressions;

namespace ExpressaoRegular
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex er = new Regex("\\d{5}-\\d{3}");

            Regex er_rg = new Regex("\\b\\d{2}.\\d{3}.\\d{3}-\\d");

            Regex er_cpf = new Regex("\\d{3}.\\d{3}.\\d{3}-\\d{2}");

            Regex er_cnpj = new Regex("\\d{2}.\\d{3}.\\d{3}\\/\\d{4}-\\d{2}");

            Regex er_ie = new Regex("\\d{3}.\\d{3}.\\d{3}.\\d{3}");

            List<string> _palavra = new List<string>();

            foreach (var item in txtConteudo.Text.Split())
            {
                _palavra.Add(item);
            }
            for ( int i = 0; i < _palavra.Count; i++)
            {
                if (er.IsMatch(_palavra[i]))
                {
                    MessageBox.Show("O CEP é: " + _palavra[i].ToString());                   
                }
                if (er_rg.IsMatch(_palavra[i]))
                {
                    MessageBox.Show("O RG é: " + _palavra[i].ToString());
                }
                if (er_cpf.IsMatch(_palavra[i]))
                {
                    MessageBox.Show("O CPF é: " + _palavra[i].ToString());
                }
                if (er_cnpj.IsMatch(_palavra[i]))
                {
                    MessageBox.Show("O CNPJ é: " + _palavra[i].ToString());
                }
                if (er_ie.IsMatch(_palavra[i]))
                {
                    MessageBox.Show("O Inscrição Estadual SP é: " + _palavra[i].ToString());
                }
            }
        }
    }
}