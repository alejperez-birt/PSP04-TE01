using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using MimeKit;
using MailKit.Net.Smtp;

namespace Eventos
{
    public partial class Form1 : Form
    {
        string[] codigoProvincia = new string[5];
        string[] nombreProvincia = new string[5];

        dynamic objDatosEventos;

        FtpWebResponse response = null;
        StreamReader reader = null;
        FtpWebRequest request = null;

        public Form1()
        {
            InitializeComponent();

            codigoProvincia[0] = "1";
            nombreProvincia[0] = "Araba";

            codigoProvincia[1] = "48";
            nombreProvincia[1] = "Bizkaia";

            codigoProvincia[2] = "20";
            nombreProvincia[2] = "Gipuzkoa";

            codigoProvincia[3] = "-3";
            nombreProvincia[3] = "Lapurdi";

            codigoProvincia[4] = "31";
            nombreProvincia[4] = "Nafarroa";

            ReiniciarControles();

        }


        private async void Btn_ActivarConsulta_Click(object sender, EventArgs e)
        {
            //Se inicializan los datos para componer la URL
            string year = "2023";
            string url = $"https://api.euskadi.eus/culture/events/v1.0/events/byYear/" + year;

            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                //Se recogen los datos de la API y se parsean
                string datosEventos = await response.Content.ReadAsStringAsync();
                objDatosEventos = JValue.Parse(datosEventos);

                //Se rellena el combobox de provincia con los valores de los datos recibidos
                //Se recorren los datos recibidos y se comprueba si la provincia de cada evento ya está en el combobox de provincia
                //Si no existe se añade el elemento al combobox
                int numeroEventos = objDatosEventos.items.Count;
                for (int i = 0; i < numeroEventos; i++)
                {
                    string provincia = DevolverNombreProvincia(objDatosEventos.items[i].provinceNoraCode.ToString());
                    bool provinciaEncontrada = false;

                    int numElemCombProv = Cmb_Provincia.Items.Count;
                    for (int j = 0; j < numElemCombProv; j++)
                    {
                        if (Cmb_Provincia.Items[j].Equals(provincia))
                        {
                            provinciaEncontrada = true;
                        }
                    }

                    if (!provinciaEncontrada)
                    {
                        Cmb_Provincia.Items.Add(provincia);
                    }
                }

                //Se selecciona el primer valor por defecto
                Cmb_Provincia.SelectedIndex = 0;

                //Se llama al método que rellena el combobox de los municipios en función de la provincia seleccionada
                RellenarMunicipios(Cmb_Provincia.SelectedItem.ToString());

                //Se llama al método que rellena el combobox de los eventos en función del municipio seleccionada
                RellenarEventos(Cmb_Municipio.SelectedItem.ToString());

                //Se llama al método que activa los controles de selección del evento
                ActivarControlesEvento();

            }

        }


        //Método que reinicia el estado de los controles al comenzar de nuevo
        private void ReiniciarControles()
        {
            Lbl_Provincia.Enabled = false;
            Cmb_Provincia.Enabled = false;
            Lbl_Municipio.Enabled = false;
            Cmb_Municipio.Enabled = false;
            Lbl_Evento.Enabled = false;
            Cmb_Evento.Enabled = false;
            Lbl_DatosEvento.Enabled = false;
            Pic_Imagen.Enabled = false;

            Btn_ActivarEnvioFTP.Enabled = false;
            Lbl_Servidor.Enabled = false;
            Txt_Servidor.Enabled = false;
            Lbl_Usuario.Enabled = false;
            Txt_Usuario.Enabled = false;
            Lbl_Contrasena.Enabled = false;
            Txt_Contrasena.Enabled = false;
            Btn_Guardar.Enabled = false;
        }


        //Método que activa los controles de envío FTP al hacer clic en el botón
        private void Btn_ActivarEnvioFTP_Click(object sender, EventArgs e)
        {
            Lbl_Servidor.Enabled = true;
            Txt_Servidor.Enabled = true;
            Lbl_Usuario.Enabled = true;
            Txt_Usuario.Enabled = true;
            Lbl_Contrasena.Enabled = true;
            Txt_Contrasena.Enabled = true;
            Btn_Guardar.Enabled = true;
        }


        //Método que activa los controles de evento y desactiva los de envío
        private void ActivarControlesEvento()
        {
            Lbl_Provincia.Enabled = true;
            Cmb_Provincia.Enabled = true;
            Lbl_Municipio.Enabled = true;
            Cmb_Municipio.Enabled = true;
            Lbl_Evento.Enabled = true;
            Cmb_Evento.Enabled = true;
            Lbl_DatosEvento.Enabled = true;
            Pic_Imagen.Enabled = true;

            Btn_ActivarEnvioFTP.Enabled = true;
            Lbl_Servidor.Enabled = false;
            Txt_Servidor.Enabled = false;
            Lbl_Usuario.Enabled = false;
            Txt_Usuario.Enabled = false;
            Lbl_Contrasena.Enabled = false;
            Txt_Contrasena.Enabled = false;
            Btn_Guardar.Enabled = false;
        }


        //Método que recoge el código de provincia recibido en los datos y devuelve el nombre de la provincia correspondiente
        private string DevolverNombreProvincia(string provinceNoraCode)
        {
            string provincia = string.Empty;
            for (int i = 0; i < codigoProvincia.Length; i++)
            {
                if (codigoProvincia[i].Equals(provinceNoraCode))
                {
                    provincia = nombreProvincia[i];
                    break;
                }
            }
            return provincia;
        }


        //Método que recoge el nombre de provincia y devuelve su código correspondiente
        private string DevolverCodigoProvincia(string provincia)
        {
            string codProvincia = string.Empty;
            for (int i = 0; i < nombreProvincia.Length; i++)
            {
                if (nombreProvincia[i].Equals(provincia))
                {
                    codProvincia = codigoProvincia[i];
                    break;
                }
            }
            return codProvincia;
        }


        //Método que limpia el nombre del fichero de espacios y caracteres especiales
        private string LimpiarCadena(string nombreFichero)
        {
            string normalizado = nombreFichero.Normalize(NormalizationForm.FormD);
            Regex reg = new Regex("[^a-zA-Z0-9]");
            nombreFichero = reg.Replace(normalizado, "");
            return nombreFichero;
        }


        //Al cambiar la provincia seleccionada se limpian los municipios y se añaden los nuevos
        private void Cmb_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_Municipio.Items.Clear();
            RellenarMunicipios(Cmb_Provincia.SelectedItem.ToString());
        }

        //Al cambiar el municipio seleccionado se limpian los eventos y se añaden los nuevos
        private void Cmb_Municipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_Evento.Items.Clear();
            RellenarEventos(Cmb_Municipio.SelectedItem.ToString());
        }

        //Al cambiar el evento seleccionado se actualiza la información del evento
        private void Cmb_Evento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numeroEventos = objDatosEventos.items.Count;
            string tituloEvento = Cmb_Evento.SelectedItem.ToString();

            // Se recorren todos los datos buscando el seleccionado
            for (int i = 0; i < numeroEventos; i++)
            {
                if (objDatosEventos.items[i].nameEs.ToString().Equals(tituloEvento))
                {
                    //Si no existen los datos los marcamos como N/D
                    String tipoEvento = "N/D";
                    if (objDatosEventos.items[i].typeEs != null) { tipoEvento = objDatosEventos.items[i].typeEs.ToString(); };
                    String horaEvento = "N/D";
                    if (objDatosEventos.items[i].startDate != null) { horaEvento = objDatosEventos.items[i].startDate.ToString(); };
                    String edificioEvento = "N/D";
                    if (objDatosEventos.items[i].establishmentEs != null) { edificioEvento = objDatosEventos.items[i].establishmentEs.ToString(); };
                    String precioEvento = "N/D";
                    if (objDatosEventos.items[i].priceEs != null) { precioEvento = objDatosEventos.items[i].priceEs.ToString(); };

                    // Se construye el texto que aparecerá en el texto de los datos del evento
                    string infoEvento = "Tipo de Evento: " + tipoEvento + "." + String.Format(Environment.NewLine) +
                                        "Nombre de Evento: " + tituloEvento + "." + String.Format(Environment.NewLine) +
                                        "Hora de Evento: " + horaEvento + "." + String.Format(Environment.NewLine) +
                                        "Edificio: " + edificioEvento + "." + String.Format(Environment.NewLine) +
                                        "Precio: " + precioEvento + ".";
                    Txt_DatosEvento.Text = infoEvento;

                    //Si existen imagenes del evento se muestra la primera de ellas
                    if (objDatosEventos.items[i].images.Count > 0)
                    {
                        String imagenEvento = objDatosEventos.items[i].images[0].imageUrl.ToString();
                        Pic_Imagen.ImageLocation = imagenEvento;
                    }
                    else
                    {
                        Pic_Imagen.ImageLocation = "";
                    }

                }

            }

        }


        //Método que rellena el combobox con los municipios de la provincia seleccionada
        private void RellenarMunicipios(string provincia)
        {
            String codProvincia = DevolverCodigoProvincia(provincia);
            int numeroEventos = objDatosEventos.items.Count;

            //Se recorren los datos recibidos y se comprueba si el municipio de cada evento ya está en el combobox de municipio
            //Si no existe se añade el elemento al combobox
            for (int i = 0; i < numeroEventos; i++)
            {
                if (objDatosEventos.items[i].provinceNoraCode.ToString().Equals(codProvincia))
                {
                    string municipio = objDatosEventos.items[i].municipalityEs.ToString();
                    bool municipioEncontrado = false;

                    int numElemCombMun = Cmb_Municipio.Items.Count;
                    for (int j = 0; j < numElemCombMun; j++)
                    {
                        if (Cmb_Municipio.Items[j].Equals(municipio))
                        {
                            municipioEncontrado = true;
                        }
                    }

                    if (!municipioEncontrado)
                    {
                        Cmb_Municipio.Items.Add(municipio);
                    }
                }
            }

            //Se selecciona el primero de los municipios por defecto
            Cmb_Municipio.SelectedIndex = 0;
        }

        //Método que rellena el combobox con los eventos del municipio seleccionado
        private void RellenarEventos(string municipio)
        {
            int numeroEventos = objDatosEventos.items.Count;

            //Se recorren los datos recibidos y se rellena el combobox de eventos con los que corresponden al municipio seleccionado
            for (int i = 0; i < numeroEventos; i++)
            {
                if (objDatosEventos.items[i].municipalityEs.ToString().Equals(municipio))
                {
                    string tituloEvento = objDatosEventos.items[i].nameEs.ToString();
                    bool eventoEncontrado = false;

                    int numElemCombEvento = Cmb_Evento.Items.Count;
                    for (int j = 0; j < numElemCombEvento; j++)
                    {
                        if (Cmb_Evento.Items[j].Equals(tituloEvento))
                        {
                            eventoEncontrado = true;
                        }
                    }

                    if (!eventoEncontrado)
                    {
                        Cmb_Evento.Items.Add(tituloEvento);
                    }
                }
            }

            //Se selecciona el primero de los eventos por defecto
            Cmb_Evento.SelectedIndex = 0;
        }


        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_Servidor.Text.Equals("") || Txt_Usuario.Text.Equals("") || Txt_Servidor.Text.Equals(""))
            {
                //Si falta alguno de los campos del FTP por rellenar se muestra un mensaje y no se hace más
                string mensaje = "Debes rellenar los campos Servidor, Usuario y Contraseña";
                string caption = "Falta información";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);

                Txt_Servidor.Focus();
            }
            else
            {
                try
                {
                    //Se inicializan los valores de conexión al servidor FTP
                    string servidor = Txt_Servidor.Text;
                    string usuario = Txt_Usuario.Text;
                    string contraseña = Txt_Contrasena.Text;

                    //Se limpia el nombre del fichero de espacios y caracteres especiales
                    string nombreFichero = Cmb_Evento.SelectedItem.ToString();
                    nombreFichero = LimpiarCadena(nombreFichero) + ".txt";

                    //Se define el metodo para subir el archivo con el dato del servidor introducido en el textbox
                    request = (FtpWebRequest)WebRequest.Create("ftp://" + Txt_Servidor.Text + "/" + nombreFichero);
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    //Se definen las credenciales de conexión con los datos introducidos
                    request.Credentials = new NetworkCredential(Txt_Usuario.Text, Txt_Contrasena.Text);

                    //Se convierte a bytes el contenido que introduciremos en el fichero
                    byte[] fileContents = Encoding.UTF8.GetBytes(Txt_DatosEvento.Text);

                    request.ContentLength = fileContents.Length;

                    using (Stream requesStream = request.GetRequestStream())
                    {
                        requesStream.Write(fileContents, 0, fileContents.Length);
                    }

                    //Se recoge la respuesta y se muestra en el textbox de datos
                    using (response = (FtpWebResponse)request.GetResponse())
                    {
                        string info = "Resultado de subida de Fichero FTP" + String.Format(Environment.NewLine) +
                                      "==================================" + String.Format(Environment.NewLine);
                        info += "Fichero subido con código:" + response.StatusDescription + String.Format(Environment.NewLine);
                        Txt_DatosEvento.Text = info;

                        //Se llama al método donde se envia el email de confirmación
                        EnviarEmail(nombreFichero, info);
                    }

                    //Se reinician los controles al estado inicial
                    ReiniciarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Txt_DatosEvento.Text = ex.Message;
                }
                finally
                {
                    if (!(reader == null))
                    {
                        reader.Close();
                    };
                    if (!(response == null))
                    {
                        response.Close();
                    };
                };

            }

        }


        private void EnviarEmail(string nombreFichero, string info)
        {
            var mensaje = new MimeMessage();

            //Se define la cuenta desde la que se envia el email
            mensaje.From.Add(new MailboxAddress("Alex Pérez", "alejperezbirt@gmail.com"));

            //Se define la cuenta a la que se envia el email
            mensaje.To.Add(new MailboxAddress("Birt - PSP", "alejperez@birt.eus"));

            //Se define el asunto del mensaje
            mensaje.Subject = nombreFichero.Replace(".txt", "");

            //Se define el cuerpo del mensaje
            mensaje.Body = new TextPart("plain")
            {
                Text = info + @"Un saludo" + String.Format(Environment.NewLine) + "Alex"
            };

            using (var client = new SmtpClient())
            {
                //Se aceptan todos los certificados
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //Conexión con el smtp de gmail
                client.Connect("smtp.gmail.com", 587, false);

                //Autentificación en el servidor
                client.Authenticate("alejperezbirt@gmail.com", "nuvlpsjdqbiamgff");

                //Envio del mensaje
                client.Send(mensaje);

                Txt_DatosEvento.Text += "Email enviado!!!";

                client.Disconnect(true);
            }
        }
    }
}