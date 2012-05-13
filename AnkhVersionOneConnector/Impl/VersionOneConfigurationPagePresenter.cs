using System;
using System.Windows.Forms;
using Ankh.ExtensionPoints.IssueTracker;
using AnkhVersionOneConnector.Impl.Controls;

namespace AnkhVersionOneConnector.Impl
{
    public class VersionOneConfigurationPagePresenter : IssueRepositoryConfigurationPage, IWin32Window
    {
        private VersionOneConfigurationPage _view;

        public override IssueRepositorySettings Settings
        {
            get
            {
                return _view != null ? _view.Settings : null;
            }
            set
            {
                if (value != null && Constants.ConnectorName.Equals(value.ConnectorName))
                {
                    if (_view != null)
                        _view.Settings = value;
                }
            }
        }

        private UserControl View
        {
            get
            {
                if (_view == null)
                {
                    _view = new VersionOneConfigurationPage();
                    _view.OnPageEvent += view_OnPageEvent;
                }
                return _view;
            }
        }

        void view_OnPageEvent(object sender, ConfigPageEventArgs e)
        {
            base.ConfigurationPageChanged(e);
        }

        public IntPtr Handle
        {
            get { return View.Handle; }
        }
    }
}