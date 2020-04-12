using System;
using System.Threading.Tasks;

namespace TestApp
{
    // all credits to https://stackoverflow.com/a/51727021/5000213
    public sealed class SessionManager
    {
        static readonly Lazy<SessionManager> lazy = new Lazy<SessionManager>(() => new SessionManager());

        public static SessionManager Instance => lazy.Value;

        SessionManager()
        {
            this.SessionDuration = TimeSpan.FromMinutes(5);
            this.sessionExpirationTime = DateTime.FromFileTimeUtc(0);
        }

        /// <summary>
        /// The duration of the session, by default this is set to 5 minutes.
        /// </summary>
        public TimeSpan SessionDuration;

        /// <summary>
        /// The OnSessionExpired event is fired when the session timer expires.
        /// This event is not fired if the timer is stopped manually using 
        /// EndTrackSession.
        /// </summary>
        public EventHandler OnSessionExpired;

        /// <summary>
        /// The session expiration time.
        /// </summary>
        DateTime sessionExpirationTime;

        /// <summary>
        /// A boolean value indicating wheter a session is currently active.
        /// Is set to true when StartTrackSessionIsCalled. Becomes false if 
        /// the session is expired manually or by expiration of the session 
        /// timer.
        /// </summary>
        public bool IsSessionActive { private set; get; }

        /// <summary>
        /// Starts the session timer.
        /// </summary>
        /// <returns>The track session async.</returns>
        public async Task StartTrackSessionAsync()
        {
            this.IsSessionActive = true;

            ExtendSession();

            await StartSessionTimerAsync();
        }

        /// <summary>
        /// Stop tracking a session manually. The OnSessionExpired will not be 
        /// called.
        /// </summary>
        public void EndTrackSession()
        {
            this.IsSessionActive = false;

            this.sessionExpirationTime = DateTime.FromFileTimeUtc(0);
        }

        /// <summary>
        /// If the session is active, then the session time is extended based 
        /// on the current time and the SessionDuration.
        /// duration.
        /// </summary>
        public void ExtendSession()
        {
            if (this.IsSessionActive == false)
            {
                return;
            }

            this.sessionExpirationTime = DateTime.Now.Add(this.SessionDuration);
        }

        /// <summary>
        /// Starts the session timer. When the session is expired and still 
        /// active the OnSessionExpired event is fired. 
        /// </summary>
        /// <returns>The session timer async.</returns>
        async Task StartSessionTimerAsync()
        {
            if (this.IsSessionActive == false)
            {
                return;
            }

            while (DateTime.Now < this.sessionExpirationTime)
            {
                await Task.Delay(1000);
            }

            if (this.IsSessionActive && this.OnSessionExpired != null)
            {
                this.IsSessionActive = false;

                this.OnSessionExpired.Invoke(this, null);
            }
        }
    }
}