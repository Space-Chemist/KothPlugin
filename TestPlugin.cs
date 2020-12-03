using NLog;
using System;
using System.IO;
using Torch;
using Torch.API;
using Nest;
using Sandbox.ModAPI;
using VRage.Game.Entity;
using VRage.ModAPI;

namespace KothPlugin
{
    public class TestPlugin : TorchPluginBase
    {
        public static bool _init;
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private Persistent<TestConfig> _config;


        public TestConfig Config
        {
            get
            {
                return this._config?.Data;
            }
        }
        
        public override void Init(ITorchBase torch)
        {
            base.Init(torch);
            this.SetupConfig();
        }

        private void SetupConfig()
        {
            
            string str = Path.Combine(this.StoragePath, "TestConfig.cfg");
            try
            {
                this._config = Persistent<TestConfig>.Load(str, true);
            }
            catch (Exception ex)
            {
                KothPlugin.TestPlugin.Log.Warn<Exception>(ex);
            }
            if (this._config?.Data != null)
                return;
            KothPlugin.TestPlugin.Log.Info("Create Default Config, because none was found!");
            this._config = new Persistent<TestConfig>(str, new TestConfig());
            this._config.Save((string)null);
        }
        
        public override void Update()
        {
            //try{
            if (MyAPIGateway.Session == null) return;

            if (!_init) Initialize();
        }
        
        private void Initialize()
        {
            _init = true;

            Communication.RegisterHandlers();
        }


        public override void Dispose()
        {
            base.Dispose();
            Communication.UnregisterHandlers();
        }
    }
}
