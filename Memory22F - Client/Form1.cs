using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory22F___Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // VARIABILI GLOBALI

        string indirizzoIP = "127.0.0.1"; // IP statico
        int porta = 5000; // Porta statica
        public Socket socket;
        public string risposta;
        private void Form1_Load(object sender, EventArgs e)
        {
            socket = AvviaConnessione(indirizzoIP, porta); // avvia la connessione al server
        }

        // utente clicca su accedi
        private void button_accedi_Click(object sender, EventArgs e)
        {
            // Ottieni il nome utente dal TextBox
            string nome = textBox_nome.Text;

            // Controlla che il nome non sia vuoto
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Inserisci un nome valido.", "Errore");
                return;
            }

            // Prepara il messaggio da inviare al server
            string messaggio = $"accedi;{nome}";

            try
            {
                // Invia il messaggio e ricevi la risposta
                string risposta = MandaMessaggio(socket, messaggio);

                if (risposta == "-1")
                {
                    // Nome duplicato
                    MessageBox.Show("Nome utente già in uso. Scegli un altro nome.", "Errore");
                }
                else if (risposta == "0")
                {
                    // Nome accettato, passa alla lobby
                    MessageBox.Show($"Accesso completato. Benvenuto {nome}!", "Accesso riuscito");

                    // Apri la finestra della lobby (Form2)
                    Form2 lobby = new Form2(socket, nome);
                    lobby.Show();
                    this.Hide(); // Nascondi la finestra attuale
                }
                else
                {
                    MessageBox.Show(risposta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'accesso: {ex.Message}", "Errore");
            }

        }

         // funzione che permette di connettersi al client
        public Socket AvviaConnessione(string indirizzoIP, int porta)
        {
            try
            {
                // Crea un socket TCP
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipAddress = IPAddress.Parse(indirizzoIP);
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, porta);

                // Connessione al server
                clientSocket.Connect(remoteEndPoint);
                MessageBox.Show("Connessione al server avvenuta con successo!", "Connesso");
                return clientSocket;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Errore durante la connessione: {e.Message}", "Errore");
                return null;
            }
        }

        public string MandaMessaggio(Socket socket, string messaggio)
        {
            try
            {
                // Invia il messaggio al server
                byte[] bufferInvio = Encoding.ASCII.GetBytes(messaggio);
                socket.Send(bufferInvio);

                // Attendi la risposta dal server
                byte[] bufferRicezione = new byte[1024];
                int bytesRicevuti = socket.Receive(bufferRicezione);
                string risposta = Encoding.ASCII.GetString(bufferRicezione, 0, bytesRicevuti);

                return risposta; // Nessuna modifica alla risposta
            }
            catch (SocketException e)
            {
                MessageBox.Show($"Errore durante la comunicazione: {e.Message}", "Errore");
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Errore imprevisto: {e.Message}", "Errore");
                return null;
            }
        }

    }
}
