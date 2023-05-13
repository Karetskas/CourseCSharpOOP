using System;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;
using Academits.Karetskas.Minesweeper.Logic.GameManager;
using Minesweeper.Gui.Controller;

namespace Minesweeper.Gui
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            OptionsManagement optionsManagement = new OptionsManagement();
            IGameManager model = new GameManager(optionsManagement);

            IMinesweeperController  controller = new MinesweeperController(model, optionsManagement);

            var mainForm = new MainForm(controller, model);

            Application.Run(mainForm);
        }
    }
}