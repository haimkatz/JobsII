using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using JobsII.Repository;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents;
using Telerik.Windows.DragDrop;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Interaction logic for RTFEditor.xaml
    /// </summary>
    public partial class RTFEditor : UserControl
    {
        public RTFEditor()
        {
            InitializeComponent();

        }

        public string mailmerge()
        {
        
            return "OK";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DragDropManager.AddDragInitializeHandler(this.fieldlv, OnDragInitialize);

            DragDropManager.AddDragOverHandler(this.radRichTextBox, OnDragOver);

            DragDropManager.AddDropHandler(this.radRichTextBox, OnDrop);
        }

        private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
        {
            string payloadData = DragDropPayloadManager.GetDataFromObject(e.Data, "DragData") as string;

            if (string.IsNullOrEmpty(payloadData))

            {

                return;

            }

            RadRichTextBox mainEditor = sender as RadRichTextBox;



            RadRichTextBox richTextBox = mainEditor.ActiveDocumentEditor as RadRichTextBox;

            //richTextBox.CurrentEditingStyle.SpanProperties.ForeColor = Colors.Red;

            Dispatcher.BeginInvoke(new Action(delegate ()

            {

                mainEditor.Focus();

                richTextBox.Insert(payloadData);

            }));
        }

        private void OnDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
        {
           

            string payloadData = DragDropPayloadManager.GetDataFromObject(e.Data, "DragData") as string;

            if (string.IsNullOrEmpty(payloadData))

            {

                return;

            }



            RadRichTextBox mainEditor = sender as RadRichTextBox;

            RadRichTextBox richTextBox = mainEditor.ActiveDocumentEditor as RadRichTextBox;



            Point point = e.GetPosition(richTextBox);

            DocumentPosition pos = richTextBox.ActiveEditorPresenter.GetDocumentPositionFromViewPoint(point);

            richTextBox.Document.CaretPosition.MoveToPosition(pos);
        }

        private void OnDragInitialize(object sender, DragInitializeEventArgs e)
        {
            e.AllowedEffects = DragDropEffects.All;



            ListView mylv = sender as ListView;



            var payload = DragDropPayloadManager.GeneratePayload(null);
            Mergefield smf = (Mergefield) mylv.SelectedItem;

            payload.SetData("DragData", smf.MergeMergename);

            e.Data = payload;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<MergeDocViewModel>();
            SimpleIoc.Default.Register<MergeDocViewModel>();
        }
    }
}