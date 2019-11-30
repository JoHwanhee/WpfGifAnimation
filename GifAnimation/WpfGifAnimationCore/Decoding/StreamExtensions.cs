using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GifAnimationCore.Decoding
{
    public static class StreamExtensions
    {
        public static Task<string> ReadStringAsync(this Stream stream, int length)
        {
            byte[] bytes = new byte[length];
            return Task.Factory.StartNew(() =>
            {
                if (stream.Read(bytes, 0, length) == length)
                {
                    return Encoding.UTF8.GetString(bytes);
                }

                throw new EndOfStreamException();
            });
        }

        public static Task<int> ReadAsync(this Stream stream, byte[] buffers, int start, int length)
        {
            return Task.Factory.StartNew(() =>
            {
                return stream.Read(buffers, start, length);
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
