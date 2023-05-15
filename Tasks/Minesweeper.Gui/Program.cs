using System;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Gui.Forms;
using Academits.Karetskas.Minesweeper.Gui.Controller;
using Academits.Karetskas.Minesweeper.Logic.GameManager;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;

namespace Academits.Karetskas.Minesweeper.Gui
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var optionsManagement = new OptionsManagement();
            IGameManager model = new GameManager(optionsManagement);

            IMinesweeperController controller = new MinesweeperController(model, optionsManagement);

            var mainForm = new MainForm(controller, model);

            Application.Run(mainForm);
        }
    }
}