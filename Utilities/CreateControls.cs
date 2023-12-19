using System.Windows.Forms;
using wf_DownloadManager.Events;
using wf_DownloadManager.Models;
using wf_DownloadManager.ThreadHandlers;

namespace wf_DownloadManager.Utilities
{
    internal class CreateControls
    {
        private Form _form;
        private int _controlCounter = 3;
        private int _controlUniqueName = 0;
        private ControlPanel _controlPanel = new();
        private Events_Factory _events_Factory = new();
        public CreateControls(Form form) => _form = form;
        public ControlPanel Begin()
        {
            _controlPanel.btn_togglePause = _CreateControl<Button>("btn_Pause",true);
            _controlPanel.val_downloadLabel = _CreateControl<Label>("val_downloadLabel");
            _controlPanel.val_status = _CreateControl<Label>("val_downloaded");
            _controlPanel.lbl_status = _CreateControl<Label>("lbl_Status");
            _controlPanel.val_percentageProgress = _CreateControl<Label>("val_progressPercentage");
            _controlPanel.val_progressBar = _CreateControl<ProgressBar>("progressBar");

            _GetControl<TextBox>("txt_Url").Text = "";

            _controlCounter += 3;

            return _controlPanel;
        }
        private T _GetControl<T>(
            string controlName) where T : Control, new() =>
                _form.Controls.Find(controlName, true).OfType<T>().FirstOrDefault() ?? new();
        private T _CreateControl<T>(
            string controlName, 
            bool initPauseEvent = false) where T : Control, new()
        {
            Control originalControl = _GetControl<Control>(controlName);
            T newControl = new ();

            if (initPauseEvent)
                ((Button)(Control)newControl).Click += (sender, e) =>
                    _events_Factory._ePause_Click(sender, e, (Button)(Control)newControl);

            newControl.Name = originalControl.Name + _controlUniqueName++;
            newControl.Text = originalControl.Text;
            newControl.Width = originalControl.Width;
            newControl.Location = new Point(originalControl.Location.X, originalControl.Location.Y + (_controlCounter - 1) * 25);
            newControl.AutoSize = true;
            newControl.Visible = true;

            _form.Controls.Add(newControl);

            return newControl;
        }
    }
}
