using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory22F___Client
{
    public partial class Form2 : Form
    {
        // Variabili globali
        public Socket socket;
        public string nome;
        public bool stato_chat = false; // Indica se la chat è visibile o meno
        private bool ascoltoAttivo = true; // Flag per interrompere in modo pulito il thread di ascolto

        public Form2(Socket socket, string nome) // Passa al Form2 il nome e il socket
        {
            InitializeComponent();
            this.KeyPreview = true; // Abilita il KeyPreview per rilevare i tasti premuti
            this.socket = socket;
            this.nome = nome;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            NascondiChat();

            // Avvia il thread per ricevere messaggi dal server
            Thread threadAscolto = new Thread(AscoltaMessaggiServer);
            threadAscolto.IsBackground = true;
            threadAscolto.Start();
        }
        // Funzione per inviare un messaggio di disconnessione
        public void InviaMessaggioDisconnessione(string messaggio)
        {
            try
            {
                byte[] bufferInvio = Encoding.ASCII.GetBytes(messaggio + "$"); // Aggiunge il delimitatore per il server
                socket.Send(bufferInvio);
            }
            catch (SocketException)
            {
                // Ignora errori legati al socket già chiuso
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'invio del messaggio di disconnessione: {ex.Message}", "Errore");
            }
        }

        public void MostraChat()
        {
            listBox_chat.Visible = true;
            textBox_chat.Visible = true;
            label_chat.Visible = true;

            // Nascondo altri elementi
            listBox_utenti_connessi.Visible = false;
            label_lista_utenti.Visible = false;
            button_PRONTO.Visible = false;
        }

        public void NascondiChat()
        {
            listBox_utenti_connessi.Visible = true;
            label_lista_utenti.Visible = true;
            button_PRONTO.Visible = true;

            listBox_chat.Visible = false;
            textBox_chat.Visible = false;
            label_chat.Visible = false;
        }

        public void InviaMessaggioChat(string messaggio)
        {
            try
            {
                // Prepara il messaggio con un prefisso specifico
                string messaggioCompleto = $"chat;{messaggio}$"; // Aggiunto il delimitatore per il server
                byte[] bufferInvio = Encoding.ASCII.GetBytes(messaggioCompleto);

                // Invia il messaggio al server
                socket.Send(bufferInvio);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'invio del messaggio: {ex.Message}", "Errore");
            }
        }

        private void textBox_chat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Verifica se il tasto premuto è Invio
            {
                string messaggio = textBox_chat.Text;

                if (messaggio.Length > 0) // Controlla che il messaggio non sia vuoto
                {
                    string chat = $"{nome}: {messaggio}";
                    InviaMessaggioChat(chat);
                    textBox_chat.Text = null;
                }
            }
        }

        public void AscoltaMessaggiServer()
        {
            try
            {
                byte[] bufferRicezione = new byte[1024];

                while (ascoltoAttivo)
                {
                    // Ricevi il messaggio dal server
                    int bytesRicevuti = socket.Receive(bufferRicezione);
                    string messaggio = Encoding.ASCII.GetString(bufferRicezione, 0, bytesRicevuti);

                    string[] messaggi_ricevuti = messaggio.Split(';');

                    // Gestisci i messaggi ricevuti
                    switch (messaggi_ricevuti[0])
                    {
                        case "chat":

                            listBox_chat.Items.Add(messaggi_ricevuti[1]);
                            System.Media.SystemSounds.Beep.Play(); // Suono di notifica
                            break;

                        case "DISCONNESSO":
                            // Mostra messaggio di disconnessione
                            listBox_chat.Items.Add($"{messaggi_ricevuti[1]} ha abbandonato la sessione.");
                            break;
                    }
                }
            }
            catch (SocketException)
            {
                // Il thread si interrompe quando il socket viene chiuso
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la ricezione dei messaggi: {ex.Message}", "Errore");
            }
        }

        // Aggiunta gestione della pressione del tasto "t"
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 't') // Verifica se il tasto premuto è 't'
            {
                if (stato_chat == false)
                {
                    MostraChat();   // Mostra la chat
                    stato_chat = true;
                }
                else
                {
                    NascondiChat(); // Nascondi la chat
                    stato_chat = false;
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ascoltoAttivo = false; // Interrompi il thread di ascolto

                if (socket != null && socket.Connected)
                {
                    // Invia messaggio di disconnessione al server
                    InviaMessaggioDisconnessione($"DISCONNESSO;{nome}$");
                }

                // Chiudi il socket
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (SocketException)
            {
                // Ignora errori legati al socket già chiuso
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la chiusura del client: {ex.Message}", "Errore");
            }
        }

    }
}
