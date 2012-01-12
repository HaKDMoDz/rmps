namespace Me.Amon.Model
{
    public sealed class ViewModel
    {
        private UserModel _UserModel;

        public ViewModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public bool MenuBarVisible { get; set; }

        public bool ToolBarVisible { get; set; }

        public bool FindBarVisible { get; set; }

        public bool InfoBarVisible { get; set; }

        public bool CatTreeVisible { get; set; }

        public bool KeyListVisible { get; set; }

        public void Load()
        {
        }

        public void Save()
        {
        }
    }
}
