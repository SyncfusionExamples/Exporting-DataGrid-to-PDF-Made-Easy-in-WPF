using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfExporting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF1cX2hIfEx3Qnxbf1x0ZFRHalhXTnJXUiweQnxTdEFiWH5ZcXVRQGRVUkx1Ww==");

            InitializeComponent();
        }


        private void OnExportToPDFClick(object sender, RoutedEventArgs e)
        {
            // Create a PDF document instance
            PdfDocument pdfDocument = new PdfDocument();

            // Export SfDataGrid to PDF
            PdfExportingOptions exportingOptions = new PdfExportingOptions() 
            {
            };

            if (OrderIDColumn.IsChecked == false)
                exportingOptions.ExcludeColumns.Add("OrderID");

            if (CustomerNameColumn.IsChecked == false)
                exportingOptions.ExcludeColumns.Add("CustomerName");

            if (QuantityColumn.IsChecked == false)
                exportingOptions.ExcludeColumns.Add("Quantity");

            if (PriceColumn.IsChecked == false)
                exportingOptions.ExcludeColumns.Add("Price");

            if ((bool)ExportHeaders.IsChecked)
                exportingOptions.PageHeaderFooterEventHandler = PdfHeaderFooterEventHandler;
            
            if ((bool)CellStyle.IsChecked)
                exportingOptions.ExportingEventHandler = GridPdfExportingEventHandler;

            if ((bool)ExportGroups.IsChecked)
                exportingOptions.ExportGroups = false;

            // Export data to the PDF document
            pdfDocument = sfDataGrid.ExportToPdf(exportingOptions);

            // Save the PDF to a file
            pdfDocument.Save("SfDataGridExport.pdf");
            pdfDocument.Close(true);

            try
            {
                // Use Process.Start to open the PDF file in the default PDF viewer
                Process.Start(new ProcessStartInfo("SfDataGridExport.pdf") { UseShellExecute = true });
            }
            catch (System.Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void GridPdfExportingEventHandler(object sender, GridPdfExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
                e.CellStyle.BackgroundBrush = PdfBrushes.LightSteelBlue;

            else if (e.CellType == ExportCellType.GroupCaptionCell)
                e.CellStyle.BackgroundBrush = PdfBrushes.LightGray;

            else if (e.CellType == ExportCellType.RecordCell)
                e.CellStyle.BackgroundBrush = PdfBrushes.Wheat;
        }

        // Define the header customization logic
        static void PdfHeaderFooterEventHandler(object sender, PdfHeaderFooterEventArgs e)
        {
            // Create a bold font for the header text
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold);

            // Get the page width to ensure proper alignment
            var width = e.PdfPage.GetClientSize().Width;

            // Create a template element for the header with a fixed height
            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 38);

            // Add text to the header at a specific position
            header.Graphics.DrawString("Order Details", font, PdfPens.Black, 70, 3);

            // Assign the header content to the top of the page
            e.PdfDocumentTemplate.Top = header;
        }

        private void OnDataGridSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (this.sfDataGrid.SelectedItems.Count > 0)
            {
                this.exportSelectedItems.IsEnabled = true;
                NoteTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.exportSelectedItems.IsEnabled = false;
                NoteTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void OnExportSelectedItemsClick(object sender, RoutedEventArgs e)
        {
            // Create a PDF document instance
            PdfDocument pdfDocument = new PdfDocument();

            // Export SfDataGrid to PDF
            PdfExportingOptions exportingOptions = new PdfExportingOptions() { };

            // Export data to the PDF document
            pdfDocument = sfDataGrid.ExportToPdf(sfDataGrid.SelectedItems, exportingOptions);

            // Save the PDF to a file
            pdfDocument.Save("SfDataGridExport.pdf");
            pdfDocument.Close(true);

            try
            {
                // Use Process.Start to open the PDF file in the default PDF viewer
                Process.Start(new ProcessStartInfo("SfDataGridExport.pdf") { UseShellExecute = true });
            }
            catch (System.Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
