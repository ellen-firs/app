namespace aboutApplication.Views;

public partial class NotePage : ContentPage
{
    public NotePage()
    {
        InitializeComponent();
        BindingContext = new Models.Note();
        LoadSavedText();
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var model = (Models.Note)BindingContext;
        model.Text = inputEntry.Text;

        try
        {
            await File.WriteAllTextAsync(model.FilePath, model.Text);
            outputLabel.Text = model.Text;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка!", $"Не получилсоь сохранить: {ex.Message}", "OK");
        }
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var model = (Models.Note)BindingContext;
        if (File.Exists(model.FilePath))
        {
            File.Delete(model.FilePath);
            model.Text = string.Empty;
            inputEntry.Text = string.Empty;
            outputLabel.Text = "";
        }
    }

    private async void LoadSavedText()
    {
        var model = (Models.Note)BindingContext;
        if (File.Exists(model.FilePath))
        {
            try
            {
                model.Text = await File.ReadAllTextAsync(model.FilePath);
                inputEntry.Text = model.Text;
                outputLabel.Text = model.Text;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", $"Ошибка загрузки: {ex.Message}", "OK");
            }
        }
    }
}