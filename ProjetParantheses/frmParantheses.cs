using System;
using System.Windows.Forms;
using System.IO;

namespace ProjetParantheses
{
    public partial class frmParantheses : Form
    {
        public frmParantheses()
        {
            InitializeComponent();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            const char PARANTHESE_OUVERTE = '(';
            const string NOM_FICHIER_A_LIRE = @"parantheses.txt";

            int nombreDePoint = 0;
            int compteurNegatifPourLaPremiereFois = 0;
            bool negatifPourLaPremiereFois = false;
            try
            {
                FileStream fichierALire = new FileStream(NOM_FICHIER_A_LIRE, FileMode.Open, FileAccess.Read);
                StreamReader lectureDeFichier = new StreamReader(fichierALire);

                while(!lectureDeFichier.EndOfStream)
                {
                    var caractereLu = (char)lectureDeFichier.Read();
                    if(caractereLu == PARANTHESE_OUVERTE)
                    {
                        nombreDePoint++;
                    }
                    else
                    {
                        nombreDePoint--;
                    }

                    if (!negatifPourLaPremiereFois)
                    {
                        compteurNegatifPourLaPremiereFois++;
                        if (nombreDePoint == -1)
                        {   
                            negatifPourLaPremiereFois = true;
                        }
                    } 
                }
                lectureDeFichier.Close();
                fichierALire.Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show("Il y a eu une erreur lors de l'exécution du programme. Voici l'erreur : " + msg.Message + " Le programme va maintenant s'arrêter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Il y a " + nombreDePoint + " points ! " + "Le programme a un score négatif après " + compteurNegatifPourLaPremiereFois + " paranthèses!", "",MessageBoxButtons.OK,MessageBoxIcon.None);
        }
    }
}
