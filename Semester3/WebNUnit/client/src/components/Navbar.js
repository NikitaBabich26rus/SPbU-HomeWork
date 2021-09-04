import React from "react"
import {AppBar, Button, IconButton, makeStyles, Toolbar, Typography} from "@material-ui/core";
import Link from '@material-ui/core/Link';

const styles = makeStyles( theme => ({
    tools: {
        display: "flex",
        flexWrap: "nowrap",
        flexDirection: "row",
        width: "100vw",
        justifyContent: "flex-end",
    }
}));

export const Header = () => {
    const classes = styles()

    return(
        <AppBar position="static">
            <Toolbar>
                <Link
                    component="button"
                    variant="h6"
                    color="inherit"
                    onClick={() => window.location.assign('/')}
                >
                    MyNUnit
                </Link>
                <div className={classes.tools}>
                    <Link
                        component="button"
                        variant="h6"
                        color="inherit"
                        onClick={() => window.location.assign('/load-assembly')}
                    >
                        Load the assembly
                    </Link>
                    <Link
                        style={{ marginLeft: "15px" }}
                        component="button"
                        variant="h6"
                        color="inherit"
                        onClick={() => window.location.assign('/run-tests')}
                    >
                        Run tests
                    </Link>
                    <Link
                        style={{ marginLeft: "15px" }}
                        component="button"
                        variant="h6"
                        color="inherit"
                        onClick={() => window.location.assign('/history')}
                    >
                        History
                    </Link>
                </div>
            </Toolbar>
        </AppBar>
    )
}