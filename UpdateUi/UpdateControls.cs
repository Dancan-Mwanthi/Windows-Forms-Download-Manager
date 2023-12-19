using System.Net;

namespace wf_DownloadManager.UpdateUi
{
    internal class UpdateControls
    {
        private UpdateUIText? _updateUIText;
        private UpdateProgressBar? _updateProgressBar;
        public void ChangeVisibility(
            bool visibility,
            Control control)
        {
            if (control.InvokeRequired)
                control.Invoke(new MethodInvoker(() =>
                {
                    control.Visible = visibility;
                }));
            else
                control.Visible = visibility;
        }
        public void ChangeText(
            Label label,
            string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(() =>
                {
                    label.Text = text;
                }));
            }
            else label.Text = text;
        }
        public void updateProgressBar(
            ProgressBar progressBar,
            DownloadProgressChangedEventArgs e)
        {
            _updateProgressBar ??= new UpdateProgressBar();

            _updateProgressBar.Begin(progressBar, e);
        }
        public void updateUiText(
            Control control,
            string text)
        {
            _updateUIText ??= new UpdateUIText();

            _updateUIText.Begin(control, text);
        }
    }
}
