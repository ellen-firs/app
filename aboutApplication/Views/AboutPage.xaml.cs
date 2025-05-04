namespace aboutApplication.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new Models.About(); 
    }

    private async void OnOpenWebsiteClicked(object sender, EventArgs e)
    {
        var model = (Models.About)BindingContext;
        await Launcher.Default.OpenAsync(model.GitHubUrl);
    }
}