using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImgToPDF
{
    public partial class PDFMain : Form
    {
        public PDFMain()
        {
            InitializeComponent();            
        }
        List<string> imageLists = new List<string>();

        private string path = Application.StartupPath;
        private void start_Click(object sender, EventArgs e)
        {
            /*//定义一个Document，并设置页面大小为A4，竖向
            iTextSharp.text.Document doc = new Document(PageSize.A4);
            try
            {
                //写实例
                PdfWriter.GetInstance(doc, new FileStream("D:\\Hello.pdf", FileMode.Create));
                #region 设置PDF的头信息，一些属性设置，在Document.Open 之前完成
                doc.AddAuthor("作者幻想Zerow");
                doc.AddCreationDate();
                doc.AddCreator("创建人幻想Zerow");
                doc.AddSubject("Dot Net 使用 itextsharp 类库创建PDF文件的例子");
                doc.AddTitle("此PDF由幻想Zerow创建，嘿嘿");
                doc.AddKeywords("ASP.NET,PDF,iTextSharp,幻想Zerow");
                //自定义头
                doc.AddHeader("Expires", "0");
                #endregion //打开document
                doc.Open();
                //载入字体
                BaseFont.AddToResourceSearch("iTextAsian.dll");
                BaseFont.AddToResourceSearch("iTextAsianCmaps.dll");
                //"UniGB-UCS2-H" "UniGB-UCS2-V"是简体中文，分别表示横向字 和 // 纵向字 //" STSong-Light"是字体名称
                BaseFont baseFT = BaseFont.CreateFont(@"c:\windows\fonts\SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT); //写入一个段落, Paragraph
                doc.Add(new Paragraph("您好， PDF !", font));
                //关闭document
                doc.Close();
                //打开PDF，看效果
                Process.Start("D:\\Hello.pdf");
            }
            catch (DocumentException de) { Console.WriteLine(de.Message); Console.ReadKey(); }
            catch (IOException io) { Console.WriteLine(io.Message); Console.ReadKey(); }
            */
            //第二种方法
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(Application.StartupPath+ "\\发票管理系统2022年国庆节前健康安全检查" + DateTime.Now.ToString("yyyyMMdd_hhmmss") +".pdf", FileMode.Create, FileAccess.ReadWrite));

                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < imageLists.Count; i++)
                {
                    if (String.IsNullOrEmpty(imageLists[i].ToString())) break;
                    //MessageBox.Show("地址："+ imageLists[i].ToString());
                    image = iTextSharp.text.Image.GetInstance(imageLists[i].ToString());

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);

                    document.NewPage();
                    document.Add(image);

                }
                MessageBox.Show("转换完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("转换失败，原因：" + ex.Message);
            }
            document.Close();
        }
        /// <summary>
        /// 单个图片文件转换为PDF格式文件
        /// </summary>
        /// <param name="jpgfile"></param>
        /// <param name="pdf"></param>
        void ConvertJPG2PDF(string jpgfile, string pdf)
        {
            var document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    document.Add(image);
                }

                document.Close();
            }
        }
        /// <summary>
        /// 批量图片转换为一个PDF文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="newpdf"></param>
        private void process(string[] files, string newpdf)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(newpdf, FileMode.Create, FileAccess.ReadWrite));

                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < files.Length; i++)
                {
                    if (String.IsNullOrEmpty(files[i])) break;

                    image = iTextSharp.text.Image.GetInstance(files[i]);

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);

                    document.NewPage();
                    document.Add(image);

                }
                MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("转换失败，原因：" + ex.Message);
            }
            document.Close();
        }

        private void SelectImgPath_Click(object sender, EventArgs e)
        {
            SelectImgPathBut();
        }
        private void SelectImgPathBut()
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                //设置打开标题、后缀
                dialog.Description = "请选消息发布目录";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathText.Text = dialog.SelectedPath;
                    //Properties.Settings.Default.messagePath = path.Text;
                    //Properties.Settings.Default.Save();
                    //加载图片
                    if (pathText.Text.Trim() == "") return;

                    imageList1.Images.Clear();
                    listView1.Items.Clear();
                    imageLists.Clear();
                    //刷新Listview
                    bindListView();
                }
            }
            catch (Exception)
            {

            }
        }
        private void startBut_Click(object sender, EventArgs e)
        {
            /*if (pathText.Text.Trim() == "") return;

            imageList1.Images.Clear();
            listView1.Items.Clear();
            imageLists.Clear();
            //刷新Listview
            bindListView();*/
        }
        private void bindListView()
        {
            DirectoryInfo dir = new DirectoryInfo(@pathText.Text.Trim());

            string[] files = new string[100];

            string ext = "";

            foreach (FileInfo d in dir.GetFiles())
            {
                ext =Path.GetExtension(pathText.Text.Trim() + d.Name);
                if (ext == ".jpg" || ext == ".jpeg") //在此只显示Jpg
                {
                    imageLists.Add(pathText.Text.Trim() + "\\" + d.Name);
                }
            }
            for (int i = 0; i < imageLists.Count; i++)
            {
                imageList1.Images.Add(System.Drawing.Image.FromFile(imageLists[i].ToString()));
                listView1.Items.Add(Path.GetFileName(imageLists[i].ToString()), i);
                listView1.Items[i].ImageIndex = i;
                listView1.Items[i].Name = imageLists[i].ToString();
            }
            listView1.Sort();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                //MessageBox.Show(info.Item.Text);
                SeeImg seeImg = new SeeImg();
                seeImg.ImgPath = pathText.Text+"\\"+ info.Item.Text;
                seeImg.ShowDialog();
            }
        }

        private void reloading_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathText.Text))
            {
                imageList1.Images.Clear();
                listView1.Items.Clear();
                imageLists.Clear();
                //刷新Listview
                bindListView();
            }
            else
            {
                MessageBox.Show("目录不存在："+pathText.Text);
            }
        }

        private void PDFMain_Shown(object sender, EventArgs e)
        {
            SelectImgPathBut();
        }
    }
}
