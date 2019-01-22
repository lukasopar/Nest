using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DesktopForms.ViewInterfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
    public class PreuzimanjeRacunaPresenter
    {
        IPreuzimanjeRacunaView _view;
        IRacunRepository _repository;
        
        public PreuzimanjeRacunaPresenter(IPreuzimanjeRacunaView view, IRacunRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            
            NapuniView();
        }
        public void NapuniView()
        {
            var lista = _repository.DohvatiSveRacune(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Racuni = lista;
        }
        public void PreuzmiPDF(Racun racun, string path)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            iTextSharp.text.pdf.BaseFont STF_Helvetica_Font = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "Cp852", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Font, 12, iTextSharp.text.Font.NORMAL);


            Paragraph p = new Paragraph();
            Chunk c1 = new Chunk("Račun\n");
            c1.Font = fontNormal;
            c1.Font.Size = 16;
            p.Add(c1);
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);


            var vet = NHibernateService.PrijavljeniVeterinar;
            Chunk c2 = new Chunk("Veterinar: " + vet.Ime + " " + vet.Prezime + "\n");
            c2.Font = fontNormal;
            Paragraph p1 = new Paragraph();
            p1.Add(c2);
            doc.Add(p1);

            Chunk c3 = new Chunk("Datum: " + racun.Datum.ToString("dd.MM.yyyy HH:mm:ss")+"\n");
            Phrase p3 = new Phrase();
            p3.Add(c3);
            doc.Add(p3);

            PdfPTable table = new PdfPTable(3);
            table.AddCell("Stavka");

            var cell = new PdfPCell();
            Chunk c4 = new Chunk("Količina");
            c4.Font = fontNormal;
            c4.Font.Size = 12;
            cell.Phrase = new iTextSharp.text.Phrase(c4);
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);



            cell = new PdfPCell();
            cell.Phrase = new iTextSharp.text.Phrase("Cijena(kn)");
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);

            foreach (var lijek in racun.LijekStavkaRacunas)
            {
                cell = new PdfPCell();
                Chunk c5 = new Chunk(lijek.LijekKodVeterinara.Lijek.Naziv);
                c5.Font = fontNormal;
                c5.Font.Size = 12;
                cell.Phrase = new Phrase(c5);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase(lijek.Kolicina + "");
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);
                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase(lijek.LijekKodVeterinara.Cijena + "");
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);
                
            }
            foreach (var postupak in racun.Postupaks)
            {
                cell = new PdfPCell();
                Chunk c6 = new Chunk(postupak.VrstaPostupka.Naziv);
                c6.Font = fontNormal;
                c6.Font.Size = 12;
                cell.Phrase = new Phrase(c6);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase("1");
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);
                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase(postupak.VrstaPostupka.Cijena + "");
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);

            }
            doc.Add(table);
            Paragraph footer = new Paragraph();
            Chunk c9 = new Chunk("Ukupno: " + racun.IzracunajUkupnuCijenu() + " kn");
            c9.Font.Size = 16;
            footer.Add(c9);
            footer.Alignment = Element.ALIGN_CENTER;
            footer.PaddingTop = 70;
            doc.Add(footer);

            doc.Close();
        }
    }
}
