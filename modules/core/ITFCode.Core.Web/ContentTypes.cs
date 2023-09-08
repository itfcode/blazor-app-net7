namespace ITFCode.Core.Web
{
    public static class ContentTypes
    {

        public const string CSV = "text/csv";
        public const string DOC = "application/msword";
        public const string DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public const string GIF = "image/gif";
        public const string JPEG = "image/jpeg";
        public const string PDF = "application/pdf";
        public const string PNG = "image/png";
        public const string XLS = "application/vnd.ms-excel";
        public const string XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        #region Application

        public const string AP1 = "application/atom+xml: Atom";
        public const string AP2 = "application/EDI-X12: EDI X12(RFC 1767)";
        public const string AP3 = "application/EDIFACT: EDI EDIFACT(RFC 1767)";
        public const string AP4 = "application/json: JavaScript Object Notation JSON(RFC 4627)";
        public const string AP5 = "application/javascript: JavaScript(RFC 4329)";
        public const string AP6 = "application/octet-stream: двоичный файл без указания формата(RFC 2046)[4]";
        public const string AP7 = "application/ogg: Ogg(RFC 5334)";
        public const string AP8 = "application/pdf: Portable Document Format, PDF(RFC 3778)";
        public const string AP9 = "application/postscript: PostScript(RFC 2046)";
        public const string AP10 = "application/soap+xml: SOAP(RFC 3902)";
        public const string AP11 = "application/font-woff: Web Open Font Format[5]";
        public const string AP12 = "application/xhtml+xml: XHTML(RFC 3236)";
        public const string AP13 = "application/xml-dtd: DTD(RFC 3023)";
        public const string AP14 = "application/xop+xml:XOP";
        public const string AP15 = "application/zip: ZIP[6]";
        public const string AP16 = "application/gzip: Gzip";
        public const string AP17 = "application/x-bittorrent : BitTorrent";
        public const string AP18 = "application/x-tex : TeX";
        public const string AP19 = "application/xml: XML";
        public const string AP20 = "application/msword: DOC";

        #endregion

        #region Audio

        public const string A1 = "audio/basic: mulaw аудио, 8 кГц, 1 канал(RFC 2046)";
        public const string A2 = "audio/L24: 24bit Linear PCM аудио, 8-48 кГц, 1-N каналов(RFC 3190)";
        public const string A3 = "audio/mp4: MP4";
        public const string A4 = "audio/aac: AAC";
        public const string A5 = "audio/mpeg: MP3 или др.MPEG(RFC 3003)";
        public const string A6 = "audio/ogg: Ogg Vorbis, Speex, Flac или др.аудио(RFC 5334)";
        public const string A7 = "audio/vorbis: Vorbis(RFC 5215)";
        public const string A8 = "audio/x-ms-wma: Windows Media Audio[7]";
        public const string A9 = "audio/x-ms-wax: Windows Media Audio перенаправление";
        public const string A10 = "audio/vnd.rn-realaudio: RealAudio[8]";
        public const string A11 = "audio/vnd.wave: WAV(RFC 2361)";
        public const string A12 = "audio/webm: WebM";

        #endregion

        #region Image

        public const string I1 = "image/gif: GIF(RFC 2045 и RFC 2046)";
        public const string I2 = "image/jpeg: JPEG(RFC 2045 и RFC 2046)";
        public const string I3 = "image/pjpeg: JPEG[9]";
        public const string I4 = "image/png: Portable Network Graphics[10] (RFC 2083)";
        public const string I5 = "image/svg+xml: SVG[11]";
        public const string I6 = "image/tiff: TIFF(RFC 3302)";
        public const string I7 = "image/vnd.microsoft.icon: ICO[12]";
        public const string I8 = "image/vnd.wap.wbmp: WBMP";
        public const string I9 = "image/webp: WebP";

        #endregion

        #region Message

        public const string MS1 = "message/http(RFC 2616)";
        public const string MS2 = "message/imdn+xml: IMDN(RFC 5438)";
        public const string MS3 = "message/partial: E-mail(RFC 2045 и RFC 2046)";
        public const string MS4 = "message/rfc822: E-mail; EML-файлы, MIME-файлы, MHT-файлы, MHTML-файлы(RFC 2045 и RFC 2046)";

        #endregion

        #region 3D-models

        public const string D1 = "model/example: (RFC 4735)";
        public const string D2 = "model/iges: IGS файлы, IGES файлы(RFC 2077)";
        public const string D3 = "model/mesh: MSH файлы, MESH файлы(RFC 2077), SILO файлы";
        public const string D4 = "model/vrml: WRL файлы, VRML файлы(RFC 2077)";
        public const string D5 = "model/x3d+binary: X3D ISO стандарт для 3D компьютерной графики, X3DB файлы";
        public const string D6 = "model/x3d+vrml: X3D ISO стандарт для 3D компьютерной графики, X3DV VRML файлы";
        public const string D7 = "model/x3d+xml: X3D ISO стандарт для 3D компьютерной графики, X3D XML файлы";

        #endregion

        #region Multipart

        public const string M1 = "multipart/mixed: MIME E-mail(RFC 2045 и RFC 2046)";
        public const string M2 = "multipart/alternative: MIME E-mail(RFC 2045 и RFC 2046)";
        public const string M3 = "multipart/related: MIME E-mail(RFC 2387 и используемое MHTML (HTML mail))";
        public const string M4 = "multipart/form-data: MIME Webform(RFC 2388)";
        public const string M5 = "multipart/signed: (RFC 1847)";
        public const string M6 = "multipart/encrypted: (RFC 1847)";

        #endregion

        #region Text

        public const string Txt1 = "text/cmd: команды";
        public const string Txt2 = "text/css: Cascading Style Sheets(RFC 2318)";
        public const string Txt3 = "text/csv: CSV(RFC 4180)";
        public const string Txt4 = "text/html: HTML(RFC 2854)";
        public const string Txt5 = "text/javascript(Obsolete) : JavaScript(RFC 4329)";
        public const string Txt6 = "text/plain: текстовые данные(RFC 2046 и RFC 3676)";
        public const string Txt7 = "text/php: Скрипт языка PHP";
        public const string Txt8 = "text/xml: Extensible Markup Language(RFC 3023)";
        public const string Txt9 = "text/markdown: файл языка разметки Markdown(RFC 7763)";
        public const string Txt10 = "text/cache-manifest: файл манифеста(RFC 2046)";

        #endregion

        #region Video

        public const string V1 = "video/mpeg: MPEG-1 (RFC 2045 и RFC 2046)";
        public const string V2 = "video/mp4: MP4(RFC 4337)";
        public const string V3 = "video/ogg: Ogg Theora или другое видео(RFC 5334)";
        public const string V4 = "video/quicktime: QuickTime[13]";
        public const string V5 = "video/webm: WebM";
        public const string V6 = "video/x-ms-wmv: Windows Media Video[7]";
        public const string V7 = "video/x-flv: FLV";
        public const string V8 = "video/3gpp: .3gpp .3gp[14]";
        public const string V9 = "video/3gpp2: .3gpp2 .3g2[14]";

        #endregion

        #region Vendor Fileds

        public const string XLSX1 = "application/vnd.oasis.opendocument.text: OpenDocument[15]";
        public const string XLSX2 = "application/vnd.oasis.opendocument.spreadsheet: OpenDocument[16]";
        public const string XLSX3 = "application/vnd.oasis.opendocument.presentation: OpenDocument[17]";
        public const string XLSX4 = "application/vnd.oasis.opendocument.graphics: OpenDocument[18]";
        public const string XLSX5 = "application/vnd.ms-excel: Microsoft Excel файлы";
        public const string XLSX6 = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet: Microsoft Excel 2007 файлы";
        public const string XLSX7 = "application/vnd.ms-excel.sheet.macroEnabled.12: Microsoft Excel 2007 файлы c макросами.XLSM";
        public const string XLSX8 = "application/vnd.ms-powerpoint: Microsoft Powerpoint файлы";
        public const string XLSX9 = "application/vnd.openxmlformats-officedocument.presentationml.presentation: Microsoft Powerpoint 2007 файлы";
        public const string XLSX10 = "application/msword: Microsoft Word файлы";
        public const string XLSX11 = "application/vnd.openxmlformats-officedocument.wordprocessingml.document: Microsoft Word 2007 файлы";
        public const string XLSX12 = "application/vnd.mozilla.xul+xml: Mozilla XUL файлы";
        public const string XLSX13 = "application/vnd.google-earth.kml+xml: KML файлы(например, для Google Earth)";

        #endregion

        #region X

        public const string X1 = "application/x-www-form-urlencoded Form Encoded Data[19]";
        public const string X2 = "application/x-dvi: DVI";
        public const string X3 = "application/x-latex: LaTeX файлы";
        public const string X4 = "application/x-font-ttf: TrueType(не зарегистрированный MIME-тип, но наиболее часто используемый)";
        public const string X5 = "application/x-shockwave-flash: Adobe Flash[20] и[21]";
        public const string X6 = "application/x-stuffit: StuffIt";
        public const string X7 = "application/x-rar-compressed: RAR";
        public const string X8 = "application/x-tar: Tarball";
        public const string X9 = "text/x-jquery-tmpl: jQuery";
        public const string X10 = "application/x-javascript:";

        #endregion

        #region PKCS files

        public const string P12 = "application/x-pkcs12";

        public const string PFX = "application/x-pkcs12";

        public const string P7B = "application/x-pkcs7-certificates";

        public const string SPC = "application/x-pkcs7-certificates";

        public const string P7R = "application/x-pkcs7-certreqresp";

        public const string P7C = "application/x-pkcs7-mime";

        public const string P7M = "application/x-pkcs7-mime";

        public const string P7S = "application/x-pkcs7-signature";

        #endregion

        public static string GetByExtension(string extension)
        {
            switch (extension.ToUpper())
            {
                case "PDF":
                    return PDF;
                case "DOC":
                    return DOC;
                case "DOCX":
                    return DOCX;
                case "XLS":
                    return XLS;
                case "XLSX":
                    return XLSX;
                case "PNG":
                    return PNG;
                case "JPEG":
                case "JPG":
                    return JPEG;
                case "GIF":
                    return GIF;
                case "CSV":
                    return CSV;
                default:
                    throw new System.Exception("Extension not defined!!!");
            }
        }
    }
}
