using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeApp
{
    public partial class Form1 : Form
    {
        private char currentPlayer = 'X'; // Başlangıç oyuncusu X
        private char[] board = new char[9]; // 3x3 Tahta için dizi
        private bool gameEnded = false; // Oyun durumu
        private void ResetBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = ' '; // Tüm hücreleri boş yap
                Controls["button" + (i + 1)].Text = ""; // Her düğmeyi boş bırak
                Controls["button" + (i + 1)].Enabled = true; // Düğmeleri aktif hale getir
            }
            currentPlayer = 'X';
            labelStatus.Text = "Sıra: Oyuncu X"; // Başlangıçta oyuncu X ile başlıyor
            gameEnded = false;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (gameEnded) return; // Oyun bittiyse işlem yapma

            Button clickedButton = sender as Button;
            int index = int.Parse(clickedButton.Name.Replace("button", "")) - 1; // Tıklanan butonun indeksi

            if (board[index] == ' ')
            {
                board[index] = currentPlayer; // Tahta dizisine oyuncunun işaretini koy
                clickedButton.Text = currentPlayer.ToString(); // Düğmeye işareti ekle
                clickedButton.Enabled = false; // Tıklanan düğmeyi devre dışı bırak
                if (currentPlayer == 'X')
                {
                    clickedButton.ForeColor = Color.Red; // X harfi kırmızı
                    clickedButton.Font = new Font("Arial", 24, FontStyle.Bold); // X için büyük ve kalın font
                }
                else
                {
                    clickedButton.ForeColor = Color.Blue; // O harfi mavi
                    clickedButton.Font = new Font("Arial", 24, FontStyle.Bold); // O için büyük ve kalın font
                }

                // Kazanan var mı kontrol et
                if (CheckWin())
                {
                    labelStatus.Text = $"Oyuncu {currentPlayer} kazandı!";
                    gameEnded = true; // Oyun bitti
                }
                else if (Array.IndexOf(board, ' ') == -1) // Tahta doluysa ve kazanan yoksa
                {
                    labelStatus.Text = "Oyun berabere!";
                    gameEnded = true; // Oyun bitti
                }
                else
                {
                    // Sıra değiştir
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    labelStatus.Text = $"Sıra: Oyuncu {currentPlayer}";
                }
            }
        }
        private bool CheckWin()
        {
            int[,] winPositions = new int[,]
            {
        { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Satırlar
        { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Sütunlar
        { 0, 4, 8 }, { 2, 4, 6 }              // Çaprazlar
            };

            for (int i = 0; i < winPositions.GetLength(0); i++)
            {
                if (board[winPositions[i, 0]] == currentPlayer &&
                    board[winPositions[i, 1]] == currentPlayer &&
                    board[winPositions[i, 2]] == currentPlayer)
                {
                    return true; // Kazanan kombinasyon varsa true dön
                }
            }
            return false; // Kazanan yoksa false dön
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            ResetBoard(); // Oyunu yeniden başlat
        }

        public Form1()
        {
            InitializeComponent();
            ResetBoard();
            for (int i = 1; i <= 9; i++)
            {
                Controls["button" + i].Click += Button_Click;
            }
        }

    }
}
