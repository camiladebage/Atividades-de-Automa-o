namespace AtividadeCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            foreach (string i in Directory.GetFiles("C:\\Users\\camil\\OneDrive\\Área de Trabalho\\UNIFAFIBE\\5º Semestre\\Tópicos Contemporâneos em Sistemas de Informação\\AtividadeCRUD\\AtividadeCRUD\\Atividade", "*.csv"))
            {
                if (i == "C:\\Users\\camil\\OneDrive\\Área de Trabalho\\UNIFAFIBE\\5º Semestre\\Tópicos Contemporâneos em Sistemas de Informação\\AtividadeCRUD\\AtividadeCRUD\\Atividade" + "\\INSERIR.csv")
                {
                    StreamReader sr = new StreamReader(i);

                    int index = 0;

                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        string[] list = line!.Split(";");

                        if (index != 0)
                        {
                            var inserir = "INSERT INTO CLIENTES VALUES('" + list[0] + "','" + list[1] + "','" + list[2] + "')";

                            ConectarSQL sql = new ConectarSQL();
                            sql.ExecutarSQL(inserir);
                        }
                        index++;
                    }
                    sr.Close();


                }

                if (i == "C:\\Users\\camil\\OneDrive\\Área de Trabalho\\UNIFAFIBE\\5º Semestre\\Tópicos Contemporâneos em Sistemas de Informação\\AtividadeCRUD\\AtividadeCRUD\\Atividade" + "\\DELETAR.csv")
                {
                    StreamReader sr = new StreamReader(i);

                    int index = 0;

                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        string[] list = line!.Split(";");

                        if (index != 0)
                        {
                            var inserir = "DELETE FROM CLIENTES WHERE ID = " + list[0];

                            ConectarSQL sql = new ConectarSQL();
                            sql.ExecutarSQL(inserir);
                        }
                        index++;
                    }
                    sr.Close();


                }

                if (i == "C:\\Users\\camil\\OneDrive\\Área de Trabalho\\UNIFAFIBE\\5º Semestre\\Tópicos Contemporâneos em Sistemas de Informação\\AtividadeCRUD\\AtividadeCRUD\\Atividade" + "\\ATUALIZAR.csv")
                {
                    StreamReader sr = new StreamReader(i);

                    int index = 0;

                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        string[] list = line!.Split(";");

                        if (index != 0)
                        {
                            var inserir = "UPDATE CLIENTES SET NOME = '" + list[1] + "' ,SOBRENOME = '" + list[2] + "' ,CPF = '" + list[3] + "' WHERE ID = " + list[0];

                            ConectarSQL sql = new ConectarSQL();
                            sql.ExecutarSQL(inserir);
                        }
                        index++;
                    }
                    sr.Close();


                }
            }
        }
    }
}