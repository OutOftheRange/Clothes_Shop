import { Link, Outlet } from "react-router-dom"

const Layout = () => {
    return (
        <div>   
            <header>
                <Link to="/">Homepage</Link>
                <Link to="/about">Log</Link>
            </header>

            <Outlet />

            <footer>Govno Project</footer>
        </div>

    )
}

export default Layout;