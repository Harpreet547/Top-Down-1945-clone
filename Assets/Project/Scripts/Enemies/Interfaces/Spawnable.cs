
// Every spawnable enemy should implement this.
interface Spawnable {
    // Seconds it takes to complete its spawning completely.
    public float secondsToCompleteSpawning { get; }
}
