public class Presenter
{
    private Model _model = default;
    private View _view = default;

    public Presenter(View view)
    {
        _model = new Model();
        _view = view;
    }

    public void OnButtonClick()
    {
        _model.Text = "Button clicked!";
        _view.UpdateText(_model.Text);
    }
}
