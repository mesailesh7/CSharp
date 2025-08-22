namespace ExampleMudWebApp.Components.Pages.SamplePages
{
    public partial class Basic
    {
        #region Fields
        // Hold private varialbes used on the page
        private const string My_Name = "Sunny";
        private int oddEvenValue;

        private string emailText = string.Empty;
        private string passwordText = string.Empty;
        private DateTime dateText = DateTime.Today;
        private string feedback = string.Empty;
        
        #endregion
        
        #region Properties
        //hold public or read-only (get) properties for use on the page
        private bool isEven
        {
            get
            {
                return oddEvenValue % 2 == 0;
            }
        }
        #endregion
        
        #region Methods
        //holds private and/or public methods that can be used by the page
        protected override void OnInitialized()
        {
            RandomValue();
            
            base.OnInitialized();
            
        }
        
        private void RandomValue()
        {
            Random rnd = new();
            
            oddEvenValue = rnd.Next(0, 25);
        }


        private void TextSubmit()
        {
            feedback = $"Email: {emailText}; Password: {passwordText}; Date = {dateText.ToString("d")}";
            
        }
        
        #endregion

    }
}
