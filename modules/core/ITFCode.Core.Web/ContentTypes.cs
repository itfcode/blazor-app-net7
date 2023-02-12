namespace ITFCode.Core.Web
{
    public static class ContentTypes
    {
        public static readonly string CSV = "text/csv";

        public static readonly string DOC = "application/msword";

        public static readonly string DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        public static readonly string GIF = "image/gif";

        public static readonly string JPEG = "image/jpeg";

        public static readonly string PDF = "application/pdf";

        public static readonly string PNG = "image/png";

        public static readonly string XLS = "application/vnd.ms-excel";

        public static readonly string XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        #region Application

        public static readonly string AP1 = "application/atom+xml: Atom";
        public static readonly string AP2 = "application/EDI-X12: EDI X12(RFC 1767)";
        public static readonly string AP3 = "application/EDIFACT: EDI EDIFACT(RFC 1767)";
        public static readonly string AP4 = "application/json: JavaScript Object Notation JSON(RFC 4627)";
        public static readonly string AP5 = "application/javascript: JavaScript(RFC 4329)";
        public static readonly string AP6 = "application/octet-stream: двоичный файл без указания формата(RFC 2046)[4]";
        public static readonly string AP7 = "application/ogg: Ogg(RFC 5334)";
        public static readonly string AP8 = "application/pdf: Portable Document Format, PDF(RFC 3778)";
        public static readonly string AP9 = "application/postscript: PostScript(RFC 2046)";
        public static readonly string AP10 = "application/soap+xml: SOAP(RFC 3902)";
        public static readonly string AP11 = "application/font-woff: Web Open Font Format[5]";
        public static readonly string AP12 = "application/xhtml+xml: XHTML(RFC 3236)";
        public static readonly string AP13 = "application/xml-dtd: DTD(RFC 3023)";
        public static readonly string AP14 = "application/xop+xml:XOP";
        public static readonly string AP15 = "application/zip: ZIP[6]";
        public static readonly string AP16 = "application/gzip: Gzip";
        public static readonly string AP17 = "application/x-bittorrent : BitTorrent";
        public static readonly string AP18 = "application/x-tex : TeX";
        public static readonly string AP19 = "application/xml: XML";
        public static readonly string AP20 = "application/msword: DOC";

        #endregion

        #region Audio

        public static readonly string A1 = "audio/basic: mulaw аудио, 8 кГц, 1 канал(RFC 2046)";
        public static readonly string A2 = "audio/L24: 24bit Linear PCM аудио, 8-48 кГц, 1-N каналов(RFC 3190)";
        public static readonly string A3 = "audio/mp4: MP4";
        public static readonly string A4 = "audio/aac: AAC";
        public static readonly string A5 = "audio/mpeg: MP3 или др.MPEG(RFC 3003)";
        public static readonly string A6 = "audio/ogg: Ogg Vorbis, Speex, Flac или др.аудио(RFC 5334)";
        public static readonly string A7 = "audio/vorbis: Vorbis(RFC 5215)";
        public static readonly string A8 = "audio/x-ms-wma: Windows Media Audio[7]";
        public static readonly string A9 = "audio/x-ms-wax: Windows Media Audio перенаправление";
        public static readonly string A10 = "audio/vnd.rn-realaudio: RealAudio[8]";
        public static readonly string A11 = "audio/vnd.wave: WAV(RFC 2361)";
        public static readonly string A12 = "audio/webm: WebM";

        #endregion

        #region Image

        public static readonly string I1 = "image/gif: GIF(RFC 2045 и RFC 2046)";
        public static readonly string I2 = "image/jpeg: JPEG(RFC 2045 и RFC 2046)";
        public static readonly string I3 = "image/pjpeg: JPEG[9]";
        public static readonly string I4 = "image/png: Portable Network Graphics[10] (RFC 2083)";
        public static readonly string I5 = "image/svg+xml: SVG[11]";
        public static readonly string I6 = "image/tiff: TIFF(RFC 3302)";
        public static readonly string I7 = "image/vnd.microsoft.icon: ICO[12]";
        public static readonly string I8 = "image/vnd.wap.wbmp: WBMP";
        public static readonly string I9 = "image/webp: WebP";

        #endregion

        #region Message

        public static readonly string MS1 = "message/http(RFC 2616)";
        public static readonly string MS2 = "message/imdn+xml: IMDN(RFC 5438)";
        public static readonly string MS3 = "message/partial: E-mail(RFC 2045 и RFC 2046)";
        public static readonly string MS4 = "message/rfc822: E-mail; EML-файлы, MIME-файлы, MHT-файлы, MHTML-файлы(RFC 2045 и RFC 2046)";

        #endregion

        #region 3D-models

        public static readonly string D1 = "model/example: (RFC 4735)";
        public static readonly string D2 = "model/iges: IGS файлы, IGES файлы(RFC 2077)";
        public static readonly string D3 = "model/mesh: MSH файлы, MESH файлы(RFC 2077), SILO файлы";
        public static readonly string D4 = "model/vrml: WRL файлы, VRML файлы(RFC 2077)";
        public static readonly string D5 = "model/x3d+binary: X3D ISO стандарт для 3D компьютерной графики, X3DB файлы";
        public static readonly string D6 = "model/x3d+vrml: X3D ISO стандарт для 3D компьютерной графики, X3DV VRML файлы";
        public static readonly string D7 = "model/x3d+xml: X3D ISO стандарт для 3D компьютерной графики, X3D XML файлы";

        #endregion

        #region Multipart

        public static readonly string M1 = "multipart/mixed: MIME E-mail(RFC 2045 и RFC 2046)";
        public static readonly string M2 = "multipart/alternative: MIME E-mail(RFC 2045 и RFC 2046)";
        public static readonly string M3 = "multipart/related: MIME E-mail(RFC 2387 и используемое MHTML (HTML mail))";
        public static readonly string M4 = "multipart/form-data: MIME Webform(RFC 2388)";
        public static readonly string M5 = "multipart/signed: (RFC 1847)";
        public static readonly string M6 = "multipart/encrypted: (RFC 1847)";

        #endregion

        #region Text

        public static readonly string Txt1 = "text/cmd: команды";
        public static readonly string Txt2 = "text/css: Cascading Style Sheets(RFC 2318)";
        public static readonly string Txt3 = "text/csv: CSV(RFC 4180)";
        public static readonly string Txt4 = "text/html: HTML(RFC 2854)";
        public static readonly string Txt5 = "text/javascript(Obsolete) : JavaScript(RFC 4329)";
        public static readonly string Txt6 = "text/plain: текстовые данные(RFC 2046 и RFC 3676)";
        public static readonly string Txt7 = "text/php: Скрипт языка PHP";
        public static readonly string Txt8 = "text/xml: Extensible Markup Language(RFC 3023)";
        public static readonly string Txt9 = "text/markdown: файл языка разметки Markdown(RFC 7763)";
        public static readonly string Txt10 = "text/cache-manifest: файл манифеста(RFC 2046)";

        #endregion

        #region Video

        public static readonly string V1 = "video/mpeg: MPEG-1 (RFC 2045 и RFC 2046)";
        public static readonly string V2 = "video/mp4: MP4(RFC 4337)";
        public static readonly string V3 = "video/ogg: Ogg Theora или другое видео(RFC 5334)";
        public static readonly string V4 = "video/quicktime: QuickTime[13]";
        public static readonly string V5 = "video/webm: WebM";
        public static readonly string V6 = "video/x-ms-wmv: Windows Media Video[7]";
        public static readonly string V7 = "video/x-flv: FLV";
        public static readonly string V8 = "video/3gpp: .3gpp .3gp[14]";
        public static readonly string V9 = "video/3gpp2: .3gpp2 .3g2[14]";

        #endregion

        #region Vendor Fileds

        public static readonly string XLSX1 = "application/vnd.oasis.opendocument.text: OpenDocument[15]";
        public static readonly string XLSX2 = "application/vnd.oasis.opendocument.spreadsheet: OpenDocument[16]";
        public static readonly string XLSX3 = "application/vnd.oasis.opendocument.presentation: OpenDocument[17]";
        public static readonly string XLSX4 = "application/vnd.oasis.opendocument.graphics: OpenDocument[18]";
        public static readonly string XLSX5 = "application/vnd.ms-excel: Microsoft Excel файлы";
        public static readonly string XLSX6 = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet: Microsoft Excel 2007 файлы";
        public static readonly string XLSX7 = "application/vnd.ms-excel.sheet.macroEnabled.12: Microsoft Excel 2007 файлы c макросами.XLSM";
        public static readonly string XLSX8 = "application/vnd.ms-powerpoint: Microsoft Powerpoint файлы";
        public static readonly string XLSX9 = "application/vnd.openxmlformats-officedocument.presentationml.presentation: Microsoft Powerpoint 2007 файлы";
        public static readonly string XLSX10 = "application/msword: Microsoft Word файлы";
        public static readonly string XLSX11 = "application/vnd.openxmlformats-officedocument.wordprocessingml.document: Microsoft Word 2007 файлы";
        public static readonly string XLSX12 = "application/vnd.mozilla.xul+xml: Mozilla XUL файлы";
        public static readonly string XLSX13 = "application/vnd.google-earth.kml+xml: KML файлы(например, для Google Earth)";

        #endregion

        #region X

        public static readonly string X1 = "application/x-www-form-urlencoded Form Encoded Data[19]";
        public static readonly string X2 = "application/x-dvi: DVI";
        public static readonly string X3 = "application/x-latex: LaTeX файлы";
        public static readonly string X4 = "application/x-font-ttf: TrueType(не зарегистрированный MIME-тип, но наиболее часто используемый)";
        public static readonly string X5 = "application/x-shockwave-flash: Adobe Flash[20] и[21]";
        public static readonly string X6 = "application/x-stuffit: StuffIt";
        public static readonly string X7 = "application/x-rar-compressed: RAR";
        public static readonly string X8 = "application/x-tar: Tarball";
        public static readonly string X9 = "text/x-jquery-tmpl: jQuery";
        public static readonly string X10 = "application/x-javascript:";

        #endregion

        #region PKCS files

        public static readonly string P12 = "application/x-pkcs12";

        public static readonly string PFX = "application/x-pkcs12";

        public static readonly string P7B = "application/x-pkcs7-certificates";

        public static readonly string SPC = "application/x-pkcs7-certificates";

        public static readonly string P7R = "application/x-pkcs7-certreqresp";

        public static readonly string P7C = "application/x-pkcs7-mime";

        public static readonly string P7M = "application/x-pkcs7-mime";

        public static readonly string P7S = "application/x-pkcs7-signature";

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
