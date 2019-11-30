using System.Collections.Generic;
using System.Linq;

namespace GifAnimationCore.Decoding
{
    public struct GifColor
    {
        public GifColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public override string ToString()
        {
            return $"#{R:x2}{G:x2}{B:x2}";
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
