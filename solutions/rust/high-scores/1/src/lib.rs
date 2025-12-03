#[derive(Debug)]
pub struct HighScores<'a> {
    _scores: &'a [u32],
}

impl<'a> HighScores<'a> {
    pub fn new(scores: &'a [u32]) -> Self {
        HighScores { _scores: scores }
    }

    pub fn scores(&self) -> &[u32] {
        self._scores
    }

    pub fn latest(&self) -> Option<u32> {
        self._scores.last().map(|x| *x)
    }

    pub fn personal_best(&self) -> Option<u32> {
        self._scores.iter().max().map(|x| *x)
    }

    pub fn personal_top_three(&self) -> Vec<u32> {
        let mut as_vec = self._scores.to_vec();

        as_vec.sort();

        as_vec.into_iter().rev().take(3).collect()
    }
}
