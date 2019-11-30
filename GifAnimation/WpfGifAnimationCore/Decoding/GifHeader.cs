using System.IO;
using System.Threading.Tasks;

namespace GifAnimationCore.Decoding
{
    public class GifHeader : GifBlock
    {
        public string Signature { get; private set; }
        public string Version { get; private set; }
        public GifLogicalScreenDescriptor LogicalScreenDescriptor { get; private set; }

        public override GifBlockKind Kind => GifBlockKind.Other;

        private GifHeader() { }
        private Stream _stream;

        public static Task<GifHeader> ReadAsync(Stream stream)
        {
            return Task.Factory.StartNew(() =>
            {
                var header = new GifHeader();

                var task = stream.ReadStringAsync(3);
                task.ContinueWith((prevTask) =>
                {
                    header.Signature = prevTask.Result;

                    if (header.Signature != "GIF")
                        throw new InvalidSignatureException("Invalid file signature: " + prevTask.Result);
                });

                task = stream.ReadStringAsync(3);
                task.ContinueWith((prevTask) =>
                {
                    header.Version = prevTask.Result;

                    if (header.Version != "87a" && header.Version != "89a")
                        throw new UnsupportedGifVersionException("Unsupported version: " + prevTask.Result);
                });

                header.LogicalScreenDescriptor = GifLogicalScreenDescriptor.ReadAsync(stream).Result;

                return header;
            });
        }
    }

    //internal abstract class GifFrame : GifBlock
    //{
    //    internal abstract GifBlockKind Kind { get; }

    //    private async Task ReadInternalAsync(Stream stream, IEnumerable<GifExtension> controlExtensions)
    //    {
    //        Descriptor = GifImageDescriptor.ReadAsync(stream).ConfigureAwait(false);
    //        if (Descriptor.HasLocalColorTable)
    //        {
    //            LocalColorTable = GifHelpers.ReadColorTableAsync(stream, Descriptor.LocalColorTableSize).ConfigureAwait(false);
    //        }
    //        ImageData = GifImageData.ReadAsync(stream).ConfigureAwait(false);
    //        Extensions = controlExtensions.ToList().AsReadOnly();
    //        GraphicControl = Extensions.OfType<GifGraphicControlExtension>().FirstOrDefault();
    //    }
    //}

    //internal class GifTrailer : GifBlock
    //{
    //    internal const int TrailerByte = 0x3B;

    //    private GifTrailer()
    //    {
    //    }

    //    internal override GifBlockKind Kind => GifBlockKind.Other;

    //    internal static Task<GifTrailer> ReadAsync()
    //    {
    //        return Task.Factory.StartNew(() => new GifTrailer());
    //    }
    //}

    //internal class GifExtension : GifBlock
    //{
    //    internal const int ExtensionIntroducer = 0x21;

    //    internal override GifBlockKind Kind => throw new NotImplementedException();
    //}

    //internal class GifGraphicControlExtension : GifExtension
    //{
    //    internal const int ExtensionLabel = 0xF9;
    //}

    //internal class GifCommentExtension : GifExtension
    //{
    //    internal const int ExtensionLabel = 0xFE;
    //}

    //internal class GifPlainTextExtension : GifExtension
    //{
    //    internal const int ExtensionLabel = 0x01;
    //}

    //internal class GifApplicationExtension : GifExtension
    //{
    //    internal const int ExtensionLabel = 0xFF;
    //}
}
