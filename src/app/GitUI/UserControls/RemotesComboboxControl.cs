using GitCommands.Remotes;

namespace GitUI.UserControls;

public partial class RemotesComboboxControl : GitModuleControl
{
    public RemotesComboboxControl()
    {
        InitializeComponent();
        InitializeComplete();
        AllowMultiselect = false;
    }

    public string SelectedRemote
    {
        get => comboBoxRemotes.Text;
        set => comboBoxRemotes.Text = value;
    }

    private bool _allowMultiselect;
    public bool AllowMultiselect
    {
        get => _allowMultiselect;
        set
        {
            if (value)
            {
                throw new NotSupportedException("Multi-select feature is not yet implemented.");
            }

            _allowMultiselect = false;
            buttonSelectMultipleRemotes.Visible = false;
        }
    }

    private void RemotesComboboxControl_Load(object sender, EventArgs e)
    {
        if (Site?.DesignMode is true)
        {
            return;
        }

        ConfigFileRemoteSettingsManager remotesManager = new(() => Module);
        comboBoxRemotes.DataSource = remotesManager.LoadRemotes(false).Select(x => x.Name).ToList();
    }
}
