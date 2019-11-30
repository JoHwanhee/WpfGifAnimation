namespace GifAnimationCore.Decoding
{
    public abstract class GifBlock
    {
        public abstract GifBlockKind Kind { get; }

        //internal static Task<GifBlock> ReadAsync(Stream stream, IEnumerable<GifExtension> controlExtensions)
        //{
        //    int blockId = stream.ReadByteAsync().ConfigureAwait(false);
        //    if (blockId < 0)
        //        throw new EndOfStreamException();
        //    switch (blockId)
        //    {
        //        case GifExtension.ExtensionIntroducer:
        //            return GifExtension.ReadAsync(stream, controlExtensions).ConfigureAwait(false);
        //        case GifFrame.ImageSeparator:
        //            return GifFrame.ReadAsync(stream, controlExtensions).ConfigureAwait(false);
        //        case GifTrailer.TrailerByte:
        //            return GifTrailer.ReadAsync().ConfigureAwait(false);
        //        default:
        //            throw GifHelpers.UnknownBlockTypeException(blockId);
        //    }
        //}
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
