using Torch;
using ProtoBuf; 

namespace KothPlugin
{
    public class TestConfig : ViewModel
    {
        [ProtoMember(1)]
        public string FuckReload { get; set; }
        
        private string _Username;
        private string _Password;
        private int _AuthToken;
        private bool _PreferBulkChanges;

        public string Username
        {
            get
            {
                return this._Username;
            }
            set => SetValue(ref _Username, value);
        }

        public string Password
        {
            get
            {
                return this._Password;
            }
            set => SetValue(ref _Password, value);
        }

        public int AuthToken
        {
            get
            {
                return this._AuthToken;
            }
            set => SetValue(ref _AuthToken, value);
        }

        public bool PreferBulkChanges
        {
            get
            {
                return this._PreferBulkChanges;
            }
            set => SetValue(ref _PreferBulkChanges, value);
        }
    }
}
