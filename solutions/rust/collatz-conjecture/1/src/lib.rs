pub fn collatz(n: u64) -> Option<u64> {
    match n {
        0 => None,
        v => {
            let mut count = 0;
            let mut current = v;
            while current != 1 {
                if current % 2 == 0 {
                    current /= 2;
                } else {
                    current = current * 3 + 1;
                }
                count += 1;
            }
            Some(count)
        }
    }
}
