﻿using TicTacToe.Codebase.Data;

namespace TicTacToe.Codebase.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
        void ResetProgress();
        void RegisterWriter(IProgressWriter progressWriter);
        void UnregisterWriter(IProgressWriter progressWriter);
    }
}