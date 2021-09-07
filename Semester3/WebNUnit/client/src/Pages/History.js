import React, {Fragment, useEffect, useState} from "react"
import {CircularProgress, Grid, makeStyles} from "@material-ui/core";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Typography from "@material-ui/core/Typography";

const useStyles = makeStyles({
    table: {
        minWidth: 650,
    },
});

export const History = () => {
    const [assemblies, setAssemblies] = useState(null)
    const [isLoaded, setIsLoaded] = useState(false)
    const classes = useStyles()

    useEffect(() => {
        getHistory()
    }, [])

    const getHistory = async () => {
        const response = await fetch('http://localhost:5000/api/Home/getHistory')
        const data = await response.json()
        let assemblies = []
        data.forEach((assembly) => {
            let tests = assembly.tests.map((test) => {
                return {
                    name: test.name,
                    result: test.result,
                    ignoreReason: test.ignoreReason,
                    time: test.time.days + '.' + test.time.hours + '.' + test.time.minutes + '.'
                        + test.time.seconds + '.' + test.time.milliseconds + '.' + test.time.ticks,
                    startTime: test.startTime
                }
            })
            const result = {
                name: assembly.name,
                tests: tests
            }
            assemblies.push(result)
        })
        setAssemblies(assemblies)
        setIsLoaded(true)
    }

    const getCell = (test) => {
        if (test.result === 'Passed'){
            return(
                <TableRow>
                    <TableCell component="th" scope="row">
                        {test.name}
                    </TableCell>
                    <TableCell align="right">{test.result}</TableCell>
                    <TableCell align="right">{test.time}</TableCell>
                    <TableCell align="right">{test.startTime}</TableCell>
                </TableRow>
            )
        }
        return(
            <TableRow>
                <TableCell component="th" scope="row">
                    {test.name}
                </TableCell>
                <TableCell align="right">{test.result}</TableCell>
                <TableCell align="right">{test.ignoreReason}</TableCell>
                <TableCell align="right">{test.startTime}</TableCell>
            </TableRow>
        )
    }
    if (!isLoaded){
        return (
            <div className="container">
                <p>Loading history...</p>
                <CircularProgress />
            </div>
        );
    }

    return(
        <Fragment>
            <Grid container xs='11' justify='center'>
                <Grid item xs='11' style={{ marginTop: '15px'}}>
                    <Typography
                        variant='h5'
                    >
                        History
                    </Typography>
                    {assemblies !== null && assemblies.map((assembly) => (
                        <>
                            <Typography
                                variant='h5'
                                style={{ marginTop: '15px'}}
                            >
                                {assembly.name}
                            </Typography>
                            <TableContainer component={Paper}>
                                <Table className={classes.table} aria-label="simple table">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell>Name</TableCell>
                                            <TableCell align="right">Passed/ Ignored/ Failed</TableCell>
                                            <TableCell align="right">Ignore message/ Time</TableCell>
                                            <TableCell align="right">Launch time</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {assembly.tests.map((test) =>
                                            getCell(test)
                                        )}
                                    </TableBody>
                                </Table>
                            </TableContainer>
                        </>
                    ))}
                </Grid>
            </Grid>
        </Fragment>
    )
}