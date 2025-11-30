fn is_prime(n: &u64) -> bool {
    let n = *n;
    if n < 2 {
        return false;
    }

    (2..).take_while(|i| i * i <= n).all(|i| n % i != 0)
}

fn rec_factors(mut fs: Vec<u64>, remainder: u64) -> Vec<u64> {
    let first_prime_factor = (2..=remainder)
        .filter(is_prime)
        .find(|i| remainder % i == 0);

    match first_prime_factor {
        Some(n) => {
            fs.push(n);
            rec_factors(fs, remainder / n)
        }
        None => fs,
    }
}

pub fn factors(n: u64) -> Vec<u64> {
    let init_factors: Vec<u64> = Vec::new();

    rec_factors(init_factors, n)
}
