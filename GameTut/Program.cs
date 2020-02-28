using System.Windows.Forms;

namespace GameTut
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 800,
                Height = 600
            };

            Game.Init(form);  
            form.Show();
            
            Application.Run(form);
        }
    }
}
