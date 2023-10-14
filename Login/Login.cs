using App;

namespace Login
{
    public partial class Login : Form
    {
        private Usuario usuario;
        public Login()
        {
            InitializeComponent();
            this.usuario = new Usuario();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            List<Usuario> usersEntrada = DeserializarUsuarios();
            if (verificarUsuario(usersEntrada))
            {
              
                PantallaPrincipal pantalla = new PantallaPrincipal(this.usuario,this);
                pantalla.StartPosition = FormStartPosition.CenterScreen;
                pantalla.Show();
                this.Hide();
                
            }
        }


        private bool verificarUsuario(List<Usuario> usuarios)
        {
            Usuario?res = null;
            bool rta = false;
            string correoEntrada = this.txtboxCorreo.Text;
            string claveEntrada = this.txtBoxClave.Text;

            
                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.correo == correoEntrada && usuario.clave == claveEntrada)
                    {
                        MessageBox.Show(usuario.ToString());
                        this.usuario = usuario;
                        res=usuario;
                        rta=true;
                        break;
                    }


                }
            
          
            if(res == null){

             MessageBox.Show("correo o contraseña invalida","Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           

            return rta;


        }


        private List<Usuario> DeserializarUsuarios()
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("../../../Data/MOCK_DATA.json"))
                {
                    string json_str = sr.ReadToEnd();

                    List<Usuario> listaUsers = (List<Usuario>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));

                    return listaUsers;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return new List<Usuario>();
            }
        }
    }
}