import React, {Fragment, useEffect, useState} from "react"
import {Button, Grid, makeStyles} from "@material-ui/core";
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

export const RunTests = () => {
    const [assemblies, setAssemblies] = useState(null)
    const classes = useStyles()

    const getTestingResult = async () => {
        const response = await fetch('http://localhost:5000/api/Home/runLoadedTests')
        const data = await response.json()
        let assemblies = []
        data.forEach((assembly) => {
            let tests = assembly.tests.map((test) => {
                return {
                    name: test.name,
                    result: test.result,
                    ignoreReason: test.ignoreReason,
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
    }

    const getCell = (test) => {
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

    return(
        <Fragment>
            <Grid container xs='11' justify='center'>
                <Grid item xs='11' style={{ marginTop: '15px'}}>
                    <Button
                        size="small"
                        variant="contained"
                        color="primary"
                        onClick={getTestingResult}
                    >
                        Run the tests
                    </Button>
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
                                            <TableCell align="right">Ignore message</TableCell>
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