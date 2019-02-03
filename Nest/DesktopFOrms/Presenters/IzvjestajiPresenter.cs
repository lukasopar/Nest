using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace DesktopForms.Presenters
{
    public class IzvjestajiPresenter
    {
        IPovijestPregledaView _view;
        private readonly UnitOfWork _unit;
        public IzvjestajiPresenter(IPovijestPregledaView view, UnitOfWork unit)
        {
            _view = view;
            view.PresenterIzvjestaji = this;
            view.Izvjestaj = true;
            view.Dodavanje = false;
            _unit = unit;
            NapuniView(DateTime.Now);
        }

        public void NapuniView(DateTime datum)
        {
            _view.Postupci = _unit.PostupakRepository.DohvatiSDetaljimaPostupkePoDatumu(NHibernateService.PrijavljeniVeterinar.Id, datum);
        }
        public void Izvjestaj(List<Postupak> postupci, DateTime datum, string path)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            iTextSharp.text.pdf.BaseFont STF_Helvetica_Font = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "Cp852", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Font, 12, iTextSharp.text.Font.NORMAL);


            Paragraph p = new Paragraph();
            Chunk c1 = new Chunk("Izvještaj\n");
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

            Chunk c3 = new Chunk("Datum: " + datum.ToString("dd.MM.yyyy HH:mm:ss") + "\n");
            Phrase p3 = new Phrase();
            p3.Add(c3);
            doc.Add(p3);

            PdfPTable table = new PdfPTable(5);
            table.AddCell("Postupak");

            var cell = new PdfPCell();
            Chunk c4 = new Chunk("Životinja");
            c4.Font = fontNormal;
            c4.Font.Size = 12;
            cell.Phrase = new iTextSharp.text.Phrase(c4);
            table.AddCell(cell);

            table.AddCell("Dijagnoza");
            table.AddCell("Terapija");  
            cell = new PdfPCell();
            cell.Phrase = new iTextSharp.text.Phrase("Cijena(kn)");
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);

            foreach (var postupak in postupci)
            {
                cell = new PdfPCell();
                Chunk c5 = new Chunk(postupak.VrstaPostupka.Naziv);
                c5.Font = fontNormal;
                c5.Font.Size = 12;
                cell.Phrase = new Phrase(c5);
                table.AddCell(cell);


                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase(postupak.Zivotinja.Ime);
                table.AddCell(cell);
                cell = new PdfPCell();
                var paragraphB = new Paragraph();
                foreach (var bolest in postupak.Bolests)
                {
                    paragraphB.Add(new Phrase(bolest.Naziv + "\n"));
                }
                if (postupak.Bolests.Count == 0)
                    paragraphB.Add(new Chunk("-"));
                table.AddCell(paragraphB);
                cell = new PdfPCell();
                var paragraphL = new Paragraph();
                foreach (var lijek in postupak.Lijeks)
                {
                    paragraphL.Add(new Phrase(lijek.Naziv + "\n"));
                }
                if (postupak.Lijeks.Count == 0)
                    paragraphL.Add(new Chunk("-"));
                table.AddCell(paragraphL);

                cell = new PdfPCell();
                cell.Phrase = new iTextSharp.text.Phrase(postupak.VrstaPostupka.Cijena + "");
                cell.HorizontalAlignment = 2;
                table.AddCell(cell);
            }
            doc.Add(table);
            
            doc.Close();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}