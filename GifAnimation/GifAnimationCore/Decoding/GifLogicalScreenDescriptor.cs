using System;
using System.IO;
using System.Threading.Tasks;

namespace GifAnimationCore.Decoding
{
    public class GifLogicalScreenDescriptor
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool HasGlobalColorTable { get; private set; }
        public int ColorResolution { get; private set; }
        public bool IsGlobalColorTableSorted { get; private set; }
        public int GlobalColorTableSize { get; private set; }
        public int BackgroundColorIndex { get; private set; }
        public double PixelAspectRatio { get; private set; }

        internal static Task<GifLogicalScreenDescriptor> ReadAsync(Stream stream)
        {
            return Task<GifLogicalScreenDescriptor>.Factory.StartNew(() =>
            {
                byte[] bytes = new byte[7];
                var glsd = new GifLogicalScreenDescriptor();
                stream.ReadAsync(bytes, 0, bytes.Length).ContinueWith((p) =>
                {
                    p.Wait();

                    glsd.Width = BitConverter.ToUInt16(bytes, 0);
                    glsd.Height = BitConverter.ToUInt16(bytes, 2);
                    byte packedFields = bytes[4];
                    glsd.HasGlobalColorTable = (packedFields & 0x80) != 0;
                    glsd.ColorResolution = ((packedFields & 0x70) >> 4) + 1;
                    glsd.IsGlobalColorTableSorted = (packedFields & 0x08) != 0;
                    glsd.GlobalColorTableSize = 1 << ((packedFields & 0x07) + 1);
                    glsd.BackgroundColorIndex = bytes[5];
                    glsd.PixelAspectRatio =
                        bytes[6] == 0
                            ? 0.0
                            : (15 + bytes[6]) / 64.0;

                }).Wait();

                return glsd;
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
