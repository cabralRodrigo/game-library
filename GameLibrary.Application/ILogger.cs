using System;

namespace GameLibrary.Application
{
    public interface ILogger
    {
        void Debug(string template);
        void Debug(string template, params object?[] values);
        void Debug(Exception ex, string template);
        void Debug(Exception ex, string template, params object?[] values);

        void Info(string template);
        void Info(string template, params object?[] values);
        void Info(Exception ex, string template);
        void Info(Exception ex, string template, params object?[] values);

        void Warn(string template);
        void Warn(string template, params object?[] values);
        void Warn(Exception ex, string template);
        void Warn(Exception ex, string template, params object?[] values);

        void Error(string template);
        void Error(string template, params object?[] values);
        void Error(Exception ex, string template);
        void Error(Exception ex, string template, params object?[] values);
    }
}