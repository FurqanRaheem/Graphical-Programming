namespace CommandParserAssignmnet
{
    internal class GlobalExceptionHandler
    {
        internal delegate void PrintErrorMessage(string message);

        private static PrintErrorMessage _printErrorMessage;

        public static void SetPrintErrorMessage(PrintErrorMessage printErrorMessage)
        {
            _printErrorMessage = printErrorMessage;
        }

        public static void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            _printErrorMessage(e.Exception.Message);
        }

        public static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($@"A system error has occured: ${e.ExceptionObject}. The program will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
