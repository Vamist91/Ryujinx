using Ryujinx.Graphics.Shader;
using System;

namespace Ryujinx.Graphics.GAL
{
    public interface IPipeline
    {
        void Barrier();

        void BeginTransformFeedback(PrimitiveTopology topology);

        void ClearBuffer(BufferHandle destination, int offset, int size, uint value);

        void ClearRenderTargetColor(int index, uint componentMask, ColorF color);

        void ClearRenderTargetDepthStencil(
            float depthValue,
            bool  depthMask,
            int   stencilValue,
            int   stencilMask);

        void CommandBufferBarrier();

        void CopyBuffer(BufferHandle source, BufferHandle destination, int srcOffset, int dstOffset, int size);

        void DispatchCompute(int groupsX, int groupsY, int groupsZ);

        void Draw(int vertexCount, int instanceCount, int firstVertex, int firstInstance);
        void DrawIndexed(
            int indexCount,
            int instanceCount,
            int firstIndex,
            int firstVertex,
            int firstInstance);

        void EndTransformFeedback();

        void MultiDrawIndirectCount(BufferRange indirectBuffer, BufferRange parameterBuffer, int maxDrawCount, int stride);
        void MultiDrawIndexedIndirectCount(BufferRange indirectBuffer, BufferRange parameterBuffer, int maxDrawCount, int stride);

        void SetAlphaTest(bool enable, float reference, CompareOp op);

        void SetBlendState(int index, BlendDescriptor blend);

        void SetDepthBias(PolygonModeMask enables, float factor, float units, float clamp);
        void SetDepthClamp(bool clamp);
        void SetDepthMode(DepthMode mode);
        void SetDepthTest(DepthTestDescriptor depthTest);

        void SetFaceCulling(bool enable, Face face);

        void SetFrontFace(FrontFace frontFace);

        void SetIndexBuffer(BufferRange buffer, IndexType type);

        void SetImage(int binding, ITexture texture, Format imageFormat);

        void SetLogicOpState(bool enable, LogicalOp op);

        void SetLineParameters(float width, bool smooth);
        void SetPointParameters(float size, bool isProgramPointSize, bool enablePointSprite, Origin origin);

        void SetPrimitiveRestart(bool enable, int index);

        void SetPrimitiveTopology(PrimitiveTopology topology);

        void SetProgram(IProgram program);

        void SetRasterizerDiscard(bool discard);

        void SetRenderTargetScale(float scale);
        void SetRenderTargetColorMasks(ReadOnlySpan<uint> componentMask);
        void SetRenderTargets(ITexture[] colors, ITexture depthStencil);

        void SetScissors(ReadOnlySpan<Rectangle<int>> regions);

        void SetStencilTest(StencilTestDescriptor stencilTest);

        void SetStorageBuffers(int first, ReadOnlySpan<BufferRange> buffers);

        void SetTextureAndSampler(int binding, ITexture texture, ISampler sampler);

        void SetTransformFeedbackBuffers(ReadOnlySpan<BufferRange> buffers);
        void SetUniformBuffers(int first, ReadOnlySpan<BufferRange> buffers);

        void SetUserClipDistance(int index, bool enableClip);

        void SetVertexAttribs(ReadOnlySpan<VertexAttribDescriptor> vertexAttribs);
        void SetVertexBuffers(ReadOnlySpan<VertexBufferDescriptor> vertexBuffers);

        void SetViewports(int first, ReadOnlySpan<Viewport> viewports);

        void TextureBarrier();
        void TextureBarrierTiled();

        bool TryHostConditionalRendering(ICounterEvent value, ulong compare, bool isEqual);
        bool TryHostConditionalRendering(ICounterEvent value, ICounterEvent compare, bool isEqual);
        void EndHostConditionalRendering();

        void UpdateRenderScale(ShaderStage stage, ReadOnlySpan<float> scales, int textureCount, int imageCount);
    }
}
