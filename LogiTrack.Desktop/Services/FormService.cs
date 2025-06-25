using LogiTrack.Desktop.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace LogiTrack.Desktop.Services
{
    public class FormService
    {
        private readonly IServiceProvider _serviceProvider;

        public FormService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateForm<T>() where T : Form
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public void ShowForm<T>(Form? mdiParent = null) where T : Form
        {
            var form = CreateForm<T>();

            if (mdiParent != null && mdiParent.IsMdiContainer)
            {
                form.MdiParent = mdiParent;
            }

            form.Show();
        }

        public DialogResult ShowDialog<T>() where T : Form
        {
            using var form = CreateForm<T>();
            return form.ShowDialog();
        }
    }
}