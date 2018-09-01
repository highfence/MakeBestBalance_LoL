namespace LogicLib

module Player =

    /// 플레이어 타입.
    type Player = {
        Name : string
        GameId : string
        Mmr : int
        Scores : float seq
    }