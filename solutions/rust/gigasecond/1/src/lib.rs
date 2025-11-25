use time::Duration;
use time::PrimitiveDateTime as DateTime;

const GIGASECOND: Duration = Duration::seconds(1_000_000_000);

// Returns a DateTime one billion seconds after start.
pub fn after(start: DateTime) -> DateTime {
    start + GIGASECOND
}
