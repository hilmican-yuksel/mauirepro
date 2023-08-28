namespace MauiApp9
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ViewCanvas.Drawable = new MyDrawable();

            ViewCanvas.DragInteraction += ViewCanvas_DragInteraction;
            ViewCanvas.StartInteraction += ViewCanvas_StartInteraction;
            ViewCanvas.EndInteraction += ViewCanvas_EndInteraction;
        }

        private void ViewCanvas_EndInteraction(object sender, TouchEventArgs e)
        {
            (ViewCanvas.Drawable as MyDrawable).IsCancel = true;
            (ViewCanvas.Drawable as MyDrawable).IsDrag = false;
            ViewCanvas.Invalidate();
        }

        private void ViewCanvas_StartInteraction(object sender, TouchEventArgs e)
        {

            (ViewCanvas.Drawable as MyDrawable).IsCancel = false;
            ViewCanvas.Invalidate();
        }

        private void ViewCanvas_DragInteraction(object sender, TouchEventArgs e)
        {
            (ViewCanvas.Drawable as MyDrawable).IsDrag = true;
            ViewCanvas.Invalidate();
        }
    }
}