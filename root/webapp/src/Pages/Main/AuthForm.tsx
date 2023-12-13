export const AuthForm = () => {
    return (
        <div>
          <h2>Authorization Interface</h2>
          <form>
            <label>
              Username:
              <input type="text" />
            </label>
            <label>
              Password:
              <input type="password" />
            </label>
            <button type="submit">Login</button>
          </form>
        </div>
      );
}