namespace ProvadeC_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
                MessageBox.Show("Erro ao acessar o banco de dados. Verifique a conexão e tente novamente.\n\n"
                    + e.Exception.GetBaseException().Message, "C#at",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Run(new FrmLogin());
        }
    }
}