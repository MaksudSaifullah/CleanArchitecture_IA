namespace Internal.Audit.Consumer.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IAConsumerSerivceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.IAServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // IAConsumerSerivceProcessInstaller
            // 
            this.IAConsumerSerivceProcessInstaller.Password = null;
            this.IAConsumerSerivceProcessInstaller.Username = null;
            // 
            // IAServiceInstaller
            // 
            this.IAServiceInstaller.ServiceName = "IAConsumerService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.IAConsumerSerivceProcessInstaller,
            this.IAServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller IAConsumerSerivceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller IAServiceInstaller;
    }
}